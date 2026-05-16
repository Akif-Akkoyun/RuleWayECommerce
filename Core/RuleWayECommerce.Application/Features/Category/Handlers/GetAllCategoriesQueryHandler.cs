using MediatR;
using RuleWayECommerce.Application.Features.Category.Queries;
using RuleWayECommerce.Application.Features.Category.Results;
using RuleWayECommerce.Application.Interfaces;
using RuleWayECommerce.Application.Interfaces.Repositories;

namespace RuleWayECommerce.Application.Features.Category.Handlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoriesQueryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetAllCategoriesQueryResult>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(category => new GetAllCategoriesQueryResult
            {
                Id = category.Id,
                Name = category.Name,
                MinimumStockQuantity = category.MinimumStockQuantity,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            }).ToList();
        }
    }
}