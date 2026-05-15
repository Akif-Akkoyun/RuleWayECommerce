using FluentValidation;
using RuleWayECommerce.Domain.Entities;

namespace RuleWayECommerce.Application.Validators
{
    public class ProductEntityValidator : AbstractValidator<ProductEntity>
    {
        public ProductEntityValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");
            RuleFor(p => p.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be zero or a positive number.");
            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("Category ID is required.");
        }
    }
}
