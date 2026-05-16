using MediatR;
using RuleWayECommerce.Application.Features.Product.Queries;
using RuleWayECommerce.Application.Features.Product.Results;
using RuleWayECommerce.Application.Interfaces;

namespace RuleWayECommerce.Application.Features.Product.Handlers
{
    public class GetByIdProductQueryHandler (IProductRepository _productRepository)
        : IRequestHandler<GetByIdProductQuery, GetByIdProductQueryResult?>
    {
        public async Task<GetByIdProductQueryResult?> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
                return null;

            return new GetByIdProductQueryResult
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                IsLive = product.IsLive,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name ?? string.Empty,
                CategoryMinimumStockQuantity = product.Category?.MinimumStockQuantity ?? 0,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }
    }
}
