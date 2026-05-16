namespace RuleWayECommerce.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public bool IsLive { get; set; } = false;
        //Nav Prop
        public CategoryEntity Category { get; set; } = null!;
        public Guid CategoryId { get; set; }
    }
}
