using MediatR;
using RuleWayECommerce.Application.Features.Product.Queries;
using RuleWayECommerce.Application.Features.Product.Results;
using RuleWayECommerce.Application.Interfaces;

namespace RuleWayECommerce.Application.Features.Product.Handlers
{
    public class GetAllProductsQueryHandler (IProductRepository _productRepository)
        : IRequestHandler<GetAllProductsQuery, List<GetAllProductsQueryResult>>
    {
        public async Task<List<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(product => new GetAllProductsQueryResult
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                IsLive = product.IsLive,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name ?? string.Empty,
                CategoryMinimumStockQuantity = product.Category?.MinimumStockQuantity ?? 0
            }).ToList();
        }
    }
}
