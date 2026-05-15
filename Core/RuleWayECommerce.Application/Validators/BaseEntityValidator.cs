using FluentValidation;
using RuleWayECommerce.Domain.Entities;

namespace RuleWayECommerce.Application.Validators
{
    public class BaseEntityValidator : AbstractValidator<BaseEntity>
    {
        public BaseEntityValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
