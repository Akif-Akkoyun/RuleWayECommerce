using MediatR;
using RuleWayECommerce.Application.Features.Category.Commands;
using RuleWayECommerce.Application.Features.Category.Results;
using RuleWayECommerce.Application.Interfaces;

namespace RuleWayECommerce.Application.Features.Category.Handlers
{
    public class UpdateCategoryCommandHandler (ICategoryRepository _categoryRepository)
        : IRequestHandler<UpdateCategoryCommand, CategoryResult?>
    {
        public async Task<CategoryResult?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                return null;

            category.Name = request.Name;
            category.MinimumStockQuantity = request.MinimumStockQuantity;
            category.UpdatedAt = DateTime.UtcNow;

            await _categoryRepository.UpdateAsync(category);

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