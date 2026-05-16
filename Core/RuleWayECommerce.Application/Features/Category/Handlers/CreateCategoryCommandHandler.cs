using MediatR;
using RuleWayECommerce.Application.Features.Category.Commands;
using RuleWayECommerce.Application.Features.Category.Results;
using RuleWayECommerce.Application.Interfaces;
using RuleWayECommerce.Domain.Entities;

namespace RuleWayECommerce.Application.Features.Category.Handlers
{
    public class CreateCategoryCommandHandler (ICategoryRepository _categoryRepository)
        : IRequestHandler<CreateCategoryCommand, CategoryResult>
    {
        public async Task<CategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                MinimumStockQuantity = request.MinimumStockQuantity,
                CreatedAt = DateTime.UtcNow
            };

            await _categoryRepository.CreateAsync(category);

            return new CategoryResult
            {
                Id = category.Id,
                Name = category.Name,
                MinimumStockQuantity = category.MinimumStockQuantity,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            };
        }
    }
}