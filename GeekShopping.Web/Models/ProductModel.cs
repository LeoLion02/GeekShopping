using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models;

public class ProductModel
{
    public int? Id { get; set; }

    [StringLength(128)]
    public string Name { get; set; }

    public decimal Price { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [StringLength(128)]
    public string CategoryName { get; set; }

    [StringLength(300)]
    public string ImageUrl { get; set; }

    [Range(1, 100)]
    public int Count { get; set; } = 1;

    public string SubstringName() 
    {
        if (Name.Length < 24) return Name;
        return $"{Name[..21]} ...";
    }

    public string SubstringDescription()
    {
        if (Name.Length < 355) return Name;
        return $"{Description[..352]} ...";
    }
}
