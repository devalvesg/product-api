using Domain.Entities;

namespace Application.Contracts.UseCases
{
    public interface IProductCrudUseCase
    {
        Task<List<ProductEntity>> GetProducts();
        Task<ProductEntity?> GetProductById(string id);
        Task<ProductEntity> CreateProduct(ProductEntity product);
        Task<ProductEntity> UpdateProduct(ProductEntity product, string id);
        Task DeleteProduct (string id);
    }
}
