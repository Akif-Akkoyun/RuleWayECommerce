using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RuleWayECommerce.Domain.Entities;
using RuleWayECommerce.Persistence.Configurations;

namespace RuleWayEcommerce.Persistence.Configurations
{
    public class ProductEntityConfiguration : BaseEntityConfiguration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Products");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.StockQuantity)
                .IsRequired();

            builder.Property(p => p.IsLive)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}