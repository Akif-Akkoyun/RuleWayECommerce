using MediatR;

namespace RuleWayECommerce.Application.Features.Product.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
