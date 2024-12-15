using AutoMapper;
using FluentValidation;
using GeekShopping.ProductAPI.Data.UnitOfWork;
using GeekShopping.ProductAPI.Interfaces.Repositories;
using GeekShopping.ProductAPI.Interfaces.Services;
using GeekShopping.ProductAPI.Models;
using GeekShopping.ProductAPI.Models.Common;
using GeekShopping.ProductAPI.ViewModels.Product;
using System.Net;

namespace GeekShopping.ProductAPI.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<ProductViewModel> _productRequestValidator;

    public ProductService(
        IMapper mapper,
        IProductRepository productRepository,
        IUnitOfWork unitOfWork,
        IValidator<ProductViewModel> productRequestValidator)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _productRequestValidator = productRequestValidator;
    }

    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
        => _mapper.Map<IEnumerable<ProductResponse>>(await _productRepository.GetAllAsync());

    public async Task<ProductResponse> GetByIdAsync(int id)
        => _mapper.Map<ProductResponse>(await _productRepository.GetByIdAsync(id));

    public async Task<Result> CreateAsync(ProductRequest productViewModel)
    {
        var validationResult = _productRequestValidator.Validate(productViewModel);
        if (!validationResult.IsValid) return Result.Failure(validationResult);
        var product = _mapper.Map<Product>(productViewModel);
        await _productRepository.CreateAsync(product);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> UpdateAsync(int id, ProductRequest productViewModel)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null) return Result.Failure("Product not found.", HttpStatusCode.NotFound);
        _mapper.Map(productViewModel, product);
        await _productRepository.UpdateAsync(product);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null) return Result.Failure("Product not found.", HttpStatusCode.NotFound);
        await _productRepository.DeleteAsync(product);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
