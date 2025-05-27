using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.Exceptions;
using Domain.Entities;

namespace Application.UseCases
{
    public class ProductCrudUseCase(IProductRepository _repository) : IProductCrudUseCase
    {
        public async Task<ProductEntity> CreateProduct(ProductEntity product)
        {
            var existsProduct = await _repository.ExistsProductName(product.Name);

            if (existsProduct)
            {
                throw new CustomException("Product name already exists");
            }

            product.RegisteredAt = DateTime.UtcNow;

            return await _repository.CreateAsync(product);
        }

        public async Task<ProductEntity?> GetProductById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<ProductEntity>> GetProducts()
        {
            return await _repository.GetAsync();
        }

        public async Task<ProductEntity> UpdateProduct(ProductEntity product, string id)
        {
            var existsProduct = await _repository.GetByIdAsync(id);

            if (existsProduct == null)
            {
                throw new CustomException("Product not found");
            }

            if (product.Name == existsProduct.Name)
            {
                throw new CustomException("Product name already exists");
            }

            return await _repository.UpdateAsync(id, product);
        }
        public async Task DeleteProduct(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
