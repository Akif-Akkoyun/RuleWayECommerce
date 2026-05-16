using MediatR;
using RuleWayECommerce.Application.Features.Category.Results;

namespace RuleWayECommerce.Application.Features.Category.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<GetAllCategoriesQueryResult>>
    {
    }
}
