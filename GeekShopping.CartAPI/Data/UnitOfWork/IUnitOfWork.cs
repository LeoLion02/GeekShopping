namespace GeekShopping.CartAPI.Data.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
