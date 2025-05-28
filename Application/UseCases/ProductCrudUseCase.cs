using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.Exceptions;
using Domain.Entities;
using MongoDB.Bson;

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

        public async Task<ProductEntity> UpdateProduct(string id, ProductEntity product)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new CustomException("Product not found");

            if (!string.IsNullOrWhiteSpace(product.Name)) existing.Name = product.Name;

            if (product.Price != 0) existing.Price = product.Price;

            if (!string.IsNullOrWhiteSpace(product.Description)) existing.Description = product.Description;

            if (!string.IsNullOrWhiteSpace(product.Description)) existing.Description = product.Description;

            if (string.IsNullOrWhiteSpace(product.Color)) existing.Color = product.Color;

            if (product.Weight != 0) existing.Weight = product.Weight;

            existing.Id = id;

            var replaced = await _repository.ReplaceAsync(existing);
            return replaced;
        }

        public async Task<ProductEntity?> GetProductById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<ProductEntity?> GetProductByName(string productName)
        {
            return await _repository.GetByNameAsync(productName);
        }

        public async Task<List<ProductEntity>> GetProducts()
        {
            return await _repository.GetAsync();
        }

        public async Task<ProductEntity> UpdateProductName(string name, string id)
        {
            var existsProduct = await _repository.GetByIdAsync(id);

            if (existsProduct == null)
            {
                throw new CustomException("Product not found");
            }

            if (name == existsProduct.Name)
            {
                throw new CustomException("Product name already exists");
            }

            return await _repository.UpdateNameAsync(id, name);
        }

        public async Task<ProductEntity> UpdateProductPrice(decimal price, string id)
        {
            var existsProduct = await _repository.GetByIdAsync(id);

            if (existsProduct == null)
            {
                throw new CustomException("Product not found");
            }

            if (price == 0)
            {
                throw new CustomException("Product price cannot be 0");
            }

            return await _repository.UpdatePriceAsync(id, price);
        }

        public async Task DeleteProduct(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
