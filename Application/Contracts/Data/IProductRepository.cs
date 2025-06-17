using Domain.Entities;

namespace Application.Contracts.Data
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAsync();
        Task<ProductEntity?> GetByIdAsync(string id);
        Task<List<ProductEntity>> GetByIdsAsync(List<string> productIds);
        Task<ProductEntity?> GetByNameAsync(string productName);
        Task<ProductEntity> CreateAsync(ProductEntity product);
        Task<ProductEntity> ReplaceAsync(ProductEntity product);
        Task<ProductEntity> UpdateNameAsync(string id, string name);
        Task<ProductEntity> UpdatePriceAsync(string id, decimal price);
        Task DeleteAsync(string id);
        Task<bool> ExistsProductName(string name);
    }
}
