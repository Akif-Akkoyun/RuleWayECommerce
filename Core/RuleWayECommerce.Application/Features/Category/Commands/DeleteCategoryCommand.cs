using MediatR;

namespace RuleWayECommerce.Application.Features.Category.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}