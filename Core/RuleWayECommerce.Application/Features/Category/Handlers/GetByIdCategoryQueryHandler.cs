using MediatR;
using RuleWayECommerce.Application.Features.Category.Queries;
using RuleWayECommerce.Application.Features.Category.Results;
using RuleWayECommerce.Application.Interfaces;
using RuleWayECommerce.Application.Interfaces.Repositories;

namespace RuleWayECommerce.Application.Features.Category.Handlers
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryQueryResult?>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetByIdCategoryQueryResult?> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                return null;

            return new GetByIdCategoryQueryResult
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