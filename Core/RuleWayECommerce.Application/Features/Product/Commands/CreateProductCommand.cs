using MediatR;
using RuleWayECommerce.Application.Features.Product.Results;

namespace RuleWayECommerce.Application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<ProductResult>
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int StockQuantity { get; set; }

        public bool IsLive { get; set; }

        public Guid CategoryId { get; set; }
    }
}
