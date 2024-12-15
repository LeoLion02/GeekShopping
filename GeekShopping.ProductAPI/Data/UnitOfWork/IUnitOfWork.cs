namespace GeekShopping.ProductAPI.Data.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
