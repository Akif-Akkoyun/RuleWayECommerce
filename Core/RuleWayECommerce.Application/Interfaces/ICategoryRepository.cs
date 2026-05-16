using RuleWayECommerce.Domain.Entities;

namespace RuleWayECommerce.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryEntity>> GetAllAsync();
        Task<CategoryEntity?> GetByIdAsync(Guid id);
        Task CreateAsync(CategoryEntity category);
        Task UpdateAsync(CategoryEntity category);
        Task DeleteAsync(CategoryEntity category);
        Task<bool> ExistsAsync(Guid id);
    }
}