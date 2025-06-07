using Application.Contracts.Data;
using Application.Enums;
using Domain.Entities;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<OrderEntity> _collection;

        public OrderRepository(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            var collectionName = options.Value.Collections.ProductCollection;
            _collection = database.GetCollection<OrderEntity>(collectionName);
        }

        public Task<OrderEntity> ChangeOrderStatusToCancelled(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderStatus> ConsultOrderStatus(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity> CreateAsync(ProductEntity product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderEntity>> GetAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
