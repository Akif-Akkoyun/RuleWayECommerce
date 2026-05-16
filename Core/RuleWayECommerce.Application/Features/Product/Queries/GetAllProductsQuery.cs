using MediatR;
using RuleWayECommerce.Application.Features.Product.Results;

namespace RuleWayECommerce.Application.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<List<GetAllProductsQueryResult>>
    {
    }
}