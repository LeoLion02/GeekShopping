namespace GeekShopping.ProductAPI.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public readonly GeekShoppingContext _context;

    public UnitOfWork(GeekShoppingContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync() 
        => await _context.SaveChangesAsync();
}
