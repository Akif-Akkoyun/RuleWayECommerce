using MediatR;
using RuleWayECommerce.Application.Features.Product.Results;

namespace RuleWayECommerce.Application.Features.Product.Queries
{
    public class FilterProductsQuery : IRequest<List<FilterProductsQueryResult>>
    {
        public string? Keyword { get; set; }

        public int? MinStock { get; set; }

        public int? MaxStock { get; set; }

        public FilterProductsQuery(string? keyword, int? minStock, int? maxStock)
        {
            Keyword = keyword;
            MinStock = minStock;
            MaxStock = maxStock;
        }
    }
}
