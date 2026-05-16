using MediatR;
using RuleWayECommerce.Application.Features.Product.Queries;
using RuleWayECommerce.Application.Features.Product.Results;
using RuleWayECommerce.Application.Interfaces;

namespace RuleWayECommerce.Application.Features.Product.Handlers
{
    public class FilterProductsQueryHandler (IProductRepository _productRepository)
        : IRequestHandler<FilterProductsQuery, List<FilterProductsQueryResult>>
    {
        public async Task<List<FilterProductsQueryResult>> Handle(FilterProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.FilterAsync(
                request.Keyword,
                request.MinStock,
                request.MaxStock);

            return products.Select(product => new FilterProductsQueryResult
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                IsLive = product.IsLive,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name ?? string.Empty
            }).ToList();
        }
    }
}
