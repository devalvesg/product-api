using Application.Contracts.Data;
using Application.Enums;
using Application.Exceptions;
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
            var collectionName = options.Value.Collections.OrderCollection;
            _collection = database.GetCollection<OrderEntity>(collectionName);
        }

        public async Task<OrderEntity> CreateAsync(OrderEntity order)
        {
            await _collection.InsertOneAsync(order);
            return order;
        }

        public async Task<List<OrderEntity>> GetOrdersByCustomerAsync(string customerId)
        {
            return await _collection.Find(x => x.CustomerId == customerId && !x.IsDeleted).ToListAsync();
        }

        public async Task<OrderEntity?> GetByIdAsync(string orderId)
        {
            return await _collection.Find(x => x.Id == orderId && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<string> ConsultOrderStatus(string orderId)
        {
            var order = await _collection.Find(x => x.Id == orderId && !x.IsDeleted).FirstOrDefaultAsync();

            if (order == null) throw new CustomException("Order not found");

            return order.Status.ToString();
        }

        public async Task<OrderEntity> ChangeOrderStatusToCancelled(OrderEntity order)
        {
            var options = new FindOneAndReplaceOptions<OrderEntity>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _collection.FindOneAndReplaceAsync(x => x.Id == order.Id, order, options);
        }
    }
}
