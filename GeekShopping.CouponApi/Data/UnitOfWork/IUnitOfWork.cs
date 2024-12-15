namespace GeekShopping.CouponApi.Data.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
