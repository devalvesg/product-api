using Domain.Entities;

namespace Application.Contracts.Data
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAsync();
        Task<ProductEntity?> GetByIdAsync(string id);
        Task<ProductEntity> CreateAsync(ProductEntity product);
        Task<ProductEntity> UpdateAsync(string id, ProductEntity product);
        Task DeleteAsync(string id);
        Task<bool> ExistsProductName(string name);
    }
}
