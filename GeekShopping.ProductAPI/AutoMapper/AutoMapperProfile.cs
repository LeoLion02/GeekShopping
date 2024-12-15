using AutoMapper;
using GeekShopping.ProductAPI.Models;
using GeekShopping.ProductAPI.ViewModels.Product;

namespace GeekShopping.ProductAPI.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductViewModel>()
            .ReverseMap();

        CreateMap<Product, ProductResponse>()
            .ReverseMap();
    }
}
