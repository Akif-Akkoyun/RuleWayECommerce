using FluentValidation;
using RuleWayECommerce.Domain.Entities;

namespace RuleWayECommerce.Application.Validators
{
    public class CategoryEntityValidator : AbstractValidator<CategoryEntity>
    {
        public CategoryEntityValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");
            RuleFor(x => x.MinimumStockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum stock quantity must be a non-negative integer.");
        }
    }
}