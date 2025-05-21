using Domain.Entities;

namespace Application.Contracts.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAsync();
        Task<Product?> GetByIdAsync(string id);
        Task CreateAsync(Product product);
        Task UpdateAsync(string id, Product product);
        Task DeleteAsync(string id);
    }
}
