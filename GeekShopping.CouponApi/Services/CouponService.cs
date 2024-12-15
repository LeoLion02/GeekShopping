using AutoMapper;
using GeekShopping.CouponApi.Data.Repositories;
using GeekShopping.CouponApi.Interfaces.Services;
using GeekShopping.CouponApi.ViewModels;

namespace GeekShopping.CouponApi.Services;

public class CouponService : ICouponService
{
    private readonly ICouponRepository _couponRepository;
    private readonly IMapper _mapper;

    public CouponService(ICouponRepository couponRepository, IMapper mapper)
    {
        _couponRepository = couponRepository;
        _mapper = mapper;
    }

    public async Task<CouponViewModel> GetByCodeAsync(string code)
        => _mapper.Map<CouponViewModel>(await _couponRepository.GetCouponByCouponCode(code));
}
