
using MediatR;
using RuleWayECommerce.Application.Features.Category.Results;

namespace RuleWayECommerce.Application.Features.Category.Queries
{
    public class GetByIdCategoryQuery : IRequest<GetByIdCategoryQueryResult>
    {
        public Guid Id { get; set; }

        public GetByIdCategoryQuery(Guid id)
        {
            Id = id;
        }
    }
}
