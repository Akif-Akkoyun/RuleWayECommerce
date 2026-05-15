using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RuleWayECommerce.Domain.Entities;

namespace RuleWayECommerce.Persistence.Configurations
{
    public class CategoryEntityConfigurations : BaseEntityConfiguration<CategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
