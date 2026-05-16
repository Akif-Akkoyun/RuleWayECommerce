namespace RuleWayECommerce.Application.Features.Product.Results
{
    public class GetByIdProductQueryResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int StockQuantity { get; set; }

        public bool IsLive { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public int CategoryMinimumStockQuantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
