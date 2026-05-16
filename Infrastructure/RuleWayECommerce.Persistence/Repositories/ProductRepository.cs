using Microsoft.EntityFrameworkCore;
using RuleWayECommerce.Application.Interfaces;
using RuleWayECommerce.Domain.Entities;
using RuleWayECommerce.Persistence.AppDbContext;

namespace RuleWayECommerce.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            product.UpdatedAt = DateTime.UtcNow;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductEntity product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductEntity>> FilterAsync(string? keyword, int? minStock, int? maxStock)
        {
            var query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();

                query = query.Where(p =>
                    p.Title.ToLower().Contains(keyword) ||
                    p.Description.ToLower().Contains(keyword) ||
                    p.Category.Name.ToLower().Contains(keyword));
            }

            if (minStock.HasValue)
            {
                query = query.Where(p => p.StockQuantity >= minStock.Value);
            }

            if (maxStock.HasValue)
            {
                query = query.Where(p => p.StockQuantity <= maxStock.Value);
            }

            return await query.ToListAsync();
        }
    }
}