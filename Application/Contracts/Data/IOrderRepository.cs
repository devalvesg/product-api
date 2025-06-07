using Application.Enums;
using Domain.Entities;

namespace Application.Contracts.Data
{
    public interface IOrderRepository
    {
        Task<List<OrderEntity>> GetAsync(string customerId);
        Task<OrderEntity?> GetByIdAsync(string orderId);
        Task<OrderEntity> CreateAsync(ProductEntity product);
        Task DeleteAsync(string orderId);
        Task<OrderStatus> ConsultOrderStatus(string orderId);
        Task<OrderEntity> ChangeOrderStatusToCancelled (string orderId);
    }
}
