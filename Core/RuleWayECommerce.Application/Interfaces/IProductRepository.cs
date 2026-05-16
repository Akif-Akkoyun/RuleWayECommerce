using RuleWayECommerce.Domain.Entities;

namespace RuleWayECommerce.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAllAsync();
        Task<ProductEntity?> GetByIdAsync(Guid id);
        Task CreateAsync(ProductEntity product);
        Task UpdateAsync(ProductEntity product);
        Task DeleteAsync(ProductEntity product);

        Task<List<ProductEntity>> FilterAsync(string? keyword, int? minStock, int? maxStock);
    }
}