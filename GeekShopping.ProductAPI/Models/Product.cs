using GeekShopping.ProductAPI.Models.Common;

namespace GeekShopping.ProductAPI.Models;

public class Product : EntityBase
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public string CategoryName { get; private set; }
    public string ImageUrl { get; private set; }
}
