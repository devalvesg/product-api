using Application.Contracts.Data;
using Domain.Entities;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
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

        public async Task<List<ProductEntity>> GetAsync() =>
            await _collection.Find(x => !x.IsDeleted).ToListAsync();

        public async Task<ProductEntity?> GetByIdAsync(string id) =>
            await _collection.Find(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();

        public async Task CreateAsync(ProductEntity product) =>
            await _collection.InsertOneAsync(product);

        public async Task UpdateAsync(string id, ProductEntity product) =>
            await _collection.ReplaceOneAsync(x => x.Id == id && !x.IsDeleted, product);

        public async Task DeleteAsync(string id, ProductEntity product) =>
            await _collection.ReplaceOneAsync(x => x.Id == id && !x.IsDeleted, product);
    }
}
