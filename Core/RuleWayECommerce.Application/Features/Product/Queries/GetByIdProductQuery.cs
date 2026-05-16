using MediatR;
using RuleWayECommerce.Application.Features.Product.Results;

namespace RuleWayECommerce.Application.Features.Product.Queries
{
    public class GetByIdProductQuery : IRequest<GetByIdProductQueryResult?>
    {
        public Guid Id { get; set; }

        public GetByIdProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
