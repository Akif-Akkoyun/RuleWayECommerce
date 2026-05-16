using MediatR;
using RuleWayECommerce.Application.Features.Category.Results;

namespace RuleWayECommerce.Application.Features.Category.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryResult>
    {
        public string Name { get; set; } = string.Empty;

        public int MinimumStockQuantity { get; set; }
    }
}