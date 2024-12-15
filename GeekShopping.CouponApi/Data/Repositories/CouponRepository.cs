using AutoMapper;
using GeekShopping.CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponApi.Data.Repositories;

public class CouponRepository : ICouponRepository
{
    private readonly GeekShoppingContext _context;

    public CouponRepository(GeekShoppingContext context, IMapper mapper)
    {
        _context = context;
    }

    public async Task<Coupon?> GetCouponByCouponCode(string code)
        => await _context.Coupons.FirstOrDefaultAsync(c => c.Code == code);
}