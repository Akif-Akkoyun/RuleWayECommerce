using MediatR;
using RuleWayECommerce.Application.Features.Product.Commands;
using RuleWayECommerce.Application.Features.Product.Results;
using RuleWayECommerce.Application.Interfaces;

namespace RuleWayECommerce.Application.Features.Product.Handlers
{
    public class UpdateProductCommandHandler (IProductRepository _productRepository, ICategoryRepository _categoryRepository)
        : IRequestHandler<UpdateProductCommand, ProductResult?>
    {
        public async Task<ProductResult?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
                return null;

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category is null)
                throw new InvalidOperationException("Category not found.");

            if (request.IsLive && request.StockQuantity < category.MinimumStockQuantity)
                throw new InvalidOperationException("Product stock quantity is below the category minimum stock quantity.");

            product.Title = request.Title;
            product.Description = request.Description;
            product.StockQuantity = request.StockQuantity;
            product.IsLive = request.IsLive;
            product.CategoryId = category.Id;
            product.Category = category;
            product.UpdatedAt = DateTime.UtcNow;

            await _productRepository.UpdateAsync(product);

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
