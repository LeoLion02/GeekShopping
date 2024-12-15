using FluentValidation;
using GeekShopping.ProductAPI.ViewModels.Product;

namespace GeekShopping.ProductAPI.Validations;

public class ProductRequestValidation : AbstractValidator<ProductViewModel>
{
    public ProductRequestValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(128);

        RuleFor(x => x.Price)
            .NotNull();

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.ImageUrl)
            .MaximumLength(300);

        RuleFor(x => x.CategoryName)
            .MaximumLength(128);
    }
}
