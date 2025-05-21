using Domain.Entities;

namespace Application.Contracts.Data
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAsync();
        Task<ProductEntity?> GetByIdAsync(string id);
        Task CreateAsync(ProductEntity product);
        Task UpdateAsync(string id, ProductEntity product);
        Task DeleteAsync(string id);
    }
}
