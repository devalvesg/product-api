using Application.Enums;
using Domain.Entities;

namespace Application.Contracts.Data
{
    public interface IOrderRepository
    {
        Task<List<OrderEntity>> GetOrdersByCustomerAsync(string customerId);
        Task<OrderEntity?> GetByIdAsync(string orderId);
        Task<OrderEntity> CreateAsync(OrderEntity order);
        Task<string> ConsultOrderStatus(string orderId);
        Task<OrderEntity> ChangeOrderStatusToCancelled (OrderEntity order);
    }
}
