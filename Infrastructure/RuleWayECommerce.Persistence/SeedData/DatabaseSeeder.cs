using Microsoft.EntityFrameworkCore;
using RuleWayECommerce.Domain.Entities;
using RuleWayECommerce.Persistence.AppDbContext;

namespace RuleWayECommerce.Persistence.SeedData
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (await context.Categories.AnyAsync() || await context.Products.AnyAsync())
                return;

            var electronicsCategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var clothingCategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var booksCategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333");

            var createdAt = DateTime.UtcNow;

            var categories = new List<CategoryEntity>
            {
                new CategoryEntity
                {
                    Id = electronicsCategoryId,
                    Name = "Electronics",
                    MinimumStockQuantity = 10,
                    CreatedAt = createdAt
                },
                new CategoryEntity
                {
                    Id = clothingCategoryId,
                    Name = "Clothing",
                    MinimumStockQuantity = 20,
                    CreatedAt = createdAt
                },
                new CategoryEntity
                {
                    Id = booksCategoryId,
                    Name = "Books",
                    MinimumStockQuantity = 5,
                    CreatedAt = createdAt
                }
            };

            var products = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Title = "iPhone 15",
                    Description = "Apple smartphone with high performance camera and display.",
                    StockQuantity = 50,
                    IsLive = true,
                    CategoryId = electronicsCategoryId,
                    CreatedAt = createdAt
                },
                new ProductEntity
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    Title = "Samsung Galaxy S24",
                    Description = "Android smartphone with AI features and AMOLED display.",
                    StockQuantity = 8,
                    IsLive = false,
                    CategoryId = electronicsCategoryId,
                    CreatedAt = createdAt
                },
                new ProductEntity
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    Title = "Basic White T-Shirt",
                    Description = "Comfortable cotton t-shirt for daily use.",
                    StockQuantity = 100,
                    IsLive = true,
                    CategoryId = clothingCategoryId,
                    CreatedAt = createdAt
                },
                new ProductEntity
                {
                    Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    Title = "Slim Fit Jeans",
                    Description = "Blue slim fit jeans with modern design.",
                    StockQuantity = 15,
                    IsLive = false,
                    CategoryId = clothingCategoryId,
                    CreatedAt = createdAt
                },
                new ProductEntity
                {
                    Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                    Title = "Clean Code",
                    Description = "Software development book about writing clean and maintainable code.",
                    StockQuantity = 25,
                    IsLive = true,
                    CategoryId = booksCategoryId,
                    CreatedAt = createdAt
                },
                new ProductEntity
                {
                    Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                    Title = "Domain-Driven Design",
                    Description = "Book about strategic and tactical software design patterns.",
                    StockQuantity = 3,
                    IsLive = false,
                    CategoryId = booksCategoryId,
                    CreatedAt = createdAt
                }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.Products.AddRangeAsync(products);

            await context.SaveChangesAsync();
        }
    }
}