namespace RuleWayECommerce.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int MinimumStockQuantity { get; set; }
        //Nav Prop
        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
