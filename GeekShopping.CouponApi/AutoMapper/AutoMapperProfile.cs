using AutoMapper;
using GeekShopping.CouponApi.Models;
using GeekShopping.CouponApi.ViewModels;

namespace GeekShopping.CartAPI.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CouponViewModel, Coupon>()
            .ReverseMap();
    }
}
