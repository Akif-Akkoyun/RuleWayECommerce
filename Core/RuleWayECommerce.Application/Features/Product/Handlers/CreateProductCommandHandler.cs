using MediatR;
using RuleWayECommerce.Application.Features.Product.Commands;
using RuleWayECommerce.Application.Features.Product.Results;
using RuleWayECommerce.Application.Interfaces;
using RuleWayECommerce.Domain.Entities;

namespace RuleWayECommerce.Application.Features.Product.Handlers
{
    public class CreateProductCommandHandler (IProductRepository _productRepository, ICategoryRepository _categoryRepository)
        : IRequestHandler<CreateProductCommand, ProductResult>
    {
        public async Task<ProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category is null)
                throw new InvalidOperationException("Category not found.");

            if (request.IsLive && request.StockQuantity < category.MinimumStockQuantity)
                throw new InvalidOperationException("Product stock quantity is below the category minimum stock quantity.");

            var product = new ProductEntity
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                StockQuantity = request.StockQuantity,
                IsLive = request.IsLive,
                CategoryId = category.Id,
                CreatedAt = DateTime.UtcNow
            };

            await _productRepository.CreateAsync(product);

            return new ProductResult
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                IsLive = product.IsLive,
                CategoryId = category.Id,
                CategoryName = category.Name,
                CategoryMinimumStockQuantity = category.MinimumStockQuantity,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }
    }
}
