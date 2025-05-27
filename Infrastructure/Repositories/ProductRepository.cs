using Application.Contracts.Data;
using Domain.Entities;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

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

        public async Task<ProductEntity> CreateAsync(ProductEntity product)
        {
            await _collection.InsertOneAsync(product);
            return product;
        }

        public async Task<ProductEntity> UpdateAsync(string id, ProductEntity product)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id && !x.IsDeleted, product);
            return product;
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
