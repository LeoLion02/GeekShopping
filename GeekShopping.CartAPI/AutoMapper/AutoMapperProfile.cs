using AutoMapper;
using GeekShopping.CartAPI.Models;
using GeekShopping.CartAPI.ViewModels;

namespace GeekShopping.CartAPI.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductViewModel, Product>()
            .ReverseMap();

        CreateMap<CartViewModel, Cart>()
            .ReverseMap();

        CreateMap<CartDetailViewModel, CartDetail>()
            .ReverseMap();

        CreateMap<CartHeaderViewModel, CartHeader>()
            .ReverseMap();
    }
}
