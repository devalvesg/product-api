using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.Enums;
using Domain.Entities;

namespace Application.UseCases
{
    public class OrderCrudUseCase(IOrderRepository _repository) : IOrderCrudUseCase
    {
        public Task<OrderStatus> ConsultOrderStatus(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity> CreateOrder(OrderEntity order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity?> GetOrderById(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderEntity>> GetOrdersByCustomer(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
