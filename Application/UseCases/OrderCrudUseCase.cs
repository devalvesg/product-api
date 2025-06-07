using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.Enums;
using Application.Exceptions;
using Domain.Entities;

namespace Application.UseCases
{
    public class OrderCrudUseCase(IOrderRepository _repository) : IOrderCrudUseCase
    {
        public async Task<OrderEntity> CreateOrder(OrderEntity order)
        {
            order.Status = OrderStatus.Pending;
            order.RegisteredAt = DateTime.UtcNow;
            return await _repository.CreateAsync(order);
        }
        
        public async Task<OrderEntity?> GetOrderById(string orderId)
        {
            return await _repository.GetByIdAsync(orderId) ?? throw new CustomException("Order not found");
        }

        public async Task<List<OrderEntity>> GetOrdersByCustomer(string customerId)
        {
            return await _repository.GetOrdersByCustomerAsync(customerId);
        }
    }
}
