using AutoMapper;
using GeekShopping.CartAPI.Data.UnitOfWork;
using GeekShopping.CartAPI.Interfaces.Repositories;
using GeekShopping.CartAPI.Interfaces.Services;
using GeekShopping.CartAPI.Messages;
using GeekShopping.CartAPI.Models;
using GeekShopping.CartAPI.Models.Common;
using GeekShopping.CartAPI.RabbitMqSender;
using GeekShopping.CartAPI.ViewModels;
using System.Net;

namespace GeekShopping.CartAPI.Services;

public class CartService : ICartService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRabbitMqMessageSender _rabbitMqMessageSender;

    public CartService(
        IMapper mapper,
        IProductRepository productRepository,
        ICartRepository cartRepository,
        IUnitOfWork unitOfWork,
        IRabbitMqMessageSender rabbitMqMessageSender)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
        _rabbitMqMessageSender = rabbitMqMessageSender;
    }

    public async Task<CartViewModel> SaveOrUpdateAsync(CartViewModel request)
    {
        var existingProduct = await _productRepository.GetByIdAsync(1/*product.Id*/);
        if (existingProduct is null)
        {
            //await _productRepository.CreateAsync(product);
            return default;
        }

        var cart = _mapper.Map<Cart>(request);
        var cartDetail = cart.CartDetails.FirstOrDefault()!;
        var product = cartDetail.Product;
        var userId = cart.CartHeader.UserId;
        var cartHeader = await _cartRepository.GetCartHeaderByUserIdAsync(userId);
        if (cartHeader is null)
        {
            await _cartRepository.AddCartHeaderAsync(cart.CartHeader);
            await _unitOfWork.SaveChangesAsync();
            cartHeader = cart.CartHeader;
        }

        var existingCartDetail = await _cartRepository.GetCartDetailByProductIdAndCartHeaderIdAsync(
            product.Id, cartHeader.Id
        );

        if (existingCartDetail is null)
        {
            cartDetail.SetCartHeaderId(cartHeader.Id);
            cartDetail.SetProduct(null);
            await _cartRepository.AddCartDetailAsync(cartDetail);
        }
        else
        {
            cartDetail.SetProduct(null);
            cartDetail.SetCount(cartDetail.Count);
            cartDetail.Id = cartDetail.Id;
            cartDetail.SetCartHeaderId(cartHeader.Id);
            await _cartRepository.UpdateCartDetailAsync(cartDetail);
        }

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CartViewModel>(request);
    }

    public async Task<Result<CartViewModel>> GetByUserIdAsync(string userId)
    {
        var cartHeader = await _cartRepository.GetCartHeaderByUserIdAsync(userId);
        if (cartHeader is null)
        {
            return Result<CartViewModel>.Failure("Cart não encontrado.", HttpStatusCode.NotFound);
        }

        var cartDetails = await _cartRepository
            .GetCartDetailsWithProductByCartHeaderIdAsync(cartHeader.Id);

        var cart = new Cart(cartHeader, cartDetails);
        return _mapper.Map<CartViewModel>(cart);
    }

    public async Task ClearCartAsync(string userId)
    {
        var cartHeader = await _cartRepository.GetCartHeaderByUserIdAsync(userId);
        if (cartHeader is null) return;

        await _cartRepository.DeleteCartDetailsWithCartHeaderIdAsync(cartHeader.Id);
        await _cartRepository.DeleteCartHeaderAsync(cartHeader);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> UpdateCouponAsync(string userId, string couponCode)
    {
        var cartHeader = await _cartRepository.GetCartHeaderByUserIdAsync(userId);
        if (cartHeader is null) return false;
        cartHeader.SetCouponCode(couponCode);
        await _cartRepository.UpdateCartHeaderAsync(cartHeader);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task RemoveFromCartAsync(int cartDetailId)
    {
        var cartDetail = await _cartRepository.GetCartDetailByIdAsync(cartDetailId);
        if (cartDetail is null) return;

        var total = await _cartRepository.GetCartDetailCountByCartHeaderId(cartDetailId);
        await _cartRepository.DeleteCartDetailAsync(cartDetail);

        if (total is 1) await _cartRepository.DeleteCartHeaderAsync(cartDetail.CartHeaderId);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Result<bool>> CheckoutAsync(CheckoutHeaderViewModel request)
    {
        if (request?.UserId is null)
            return Result<bool>.Failure("userId é obrigatorio");

        var cart = await GetByUserIdAsync(request.UserId);
        if (cart is null) return Result<bool>.Failure("Not found", HttpStatusCode.NotFound);

        request.CartDetails = cart.Value.CartDetails;
        request.Time = DateTime.Now;

        //_rabbitMqMessageSender.SendMessage(request, "checkoutqueue");

        return true;
    }

    Task ICartService.CheckoutAsync(CheckoutHeaderViewModel request)
    {
        throw new NotImplementedException();
    }
}