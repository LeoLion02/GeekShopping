namespace GeekShopping.CartAPI.Models;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; set; }
    public string CategoryName { get; private set; }
    public string ImageUrl { get; private set; }
}