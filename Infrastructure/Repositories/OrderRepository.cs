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

        public async Task<OrderEntity> CreateAsync(OrderEntity order)
        {
            await _collection.InsertOneAsync(order);
            return order;
        }

        public async Task<List<OrderEntity>> GetOrdersByCustomerAsync(string customerId)
        {
            return await _collection.Find(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<OrderEntity?> GetByIdAsync(string orderId)
        {
            return await _collection.Find(x => x.Id == orderId).FirstOrDefaultAsync();
        }

        public async Task<OrderStatus> ConsultOrderStatus(string orderId)
        {
            var order = await _collection.Find(x => x.Id == orderId).FirstOrDefaultAsync();
            return order.Status;
        }

        public async Task<OrderEntity> ChangeOrderStatusToCancelled(OrderEntity order)
        {
            return await _collection.FindOneAndReplaceAsync(x => x.Id == order.Id, order);
        }
    }
}
