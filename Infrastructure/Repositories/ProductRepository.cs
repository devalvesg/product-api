using Application.Contracts.Data;
using Domain.Entities;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<ProductEntity> _collection;

        public ProductRepository(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            var collectionName = options.Value.Collections.ProductCollection;
            _collection = database.GetCollection<ProductEntity>(collectionName);
        }

        public async Task<List<ProductEntity>> GetAsync()
        {
            return await _collection.Find(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<ProductEntity?> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
        }
        
        public async Task<ProductEntity?> GetByNameAsync(string productName)
        {
            return await _collection.Find(x => x.Name.ToLower() == productName.ToLower() && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<ProductEntity> CreateAsync(ProductEntity product)
        {
            await _collection.InsertOneAsync(product);
            return product;
        }
        
        public async Task<ProductEntity> ReplaceAsync(ProductEntity product)
        {
            var filter = Builders<ProductEntity>.Filter.Eq(p => p.Id, product.Id);
            var options = new FindOneAndReplaceOptions<ProductEntity>
            {
                ReturnDocument = ReturnDocument.After 
            };

            var replaced = await _collection.FindOneAndReplaceAsync(filter, product, options);

            return replaced;
        }

        public async Task<ProductEntity> UpdateNameAsync(string id, string name)
        {
            var filter = Builders<ProductEntity>
                .Filter
                .Eq(p => p.Id, id);

            var update = Builders<ProductEntity>
                .Update
                .Set(p => p.Name, name);

            var options = new FindOneAndUpdateOptions<ProductEntity>
            {
                ReturnDocument = ReturnDocument.After
            };

            var updatedProduct = await _collection.FindOneAndUpdateAsync(
                filter,
                update,
                options
            );

            return updatedProduct;
        }

        public async Task<ProductEntity> UpdatePriceAsync(string id, decimal price)
        {
            var filter = Builders<ProductEntity>
                .Filter
                .Eq(p => p.Id, id);

            var update = Builders<ProductEntity>
                .Update
                .Set(p => p.Price, price);

            var options = new FindOneAndUpdateOptions<ProductEntity>
            {
                ReturnDocument = ReturnDocument.After
            };

            var updatedProduct = await _collection.FindOneAndUpdateAsync(
                filter,
                update,
                options
            );

            return updatedProduct;
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<ProductEntity>.Filter.And(
                Builders<ProductEntity>.Filter.Eq(x => x.Id, id),
                Builders<ProductEntity>.Filter.Eq(x => x.IsDeleted, false)
            );

            var update = Builders<ProductEntity>.Update.Set(x => x.IsDeleted, true);

            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<bool> ExistsProductName(string name)
        {
            return await _collection.Find(x => x.Name == name).AnyAsync();
        }
    }
}
