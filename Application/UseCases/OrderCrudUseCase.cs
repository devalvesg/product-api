using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.Enums;
using Application.Exceptions;
using Application.RequestObjects;
using Domain.Entities;

namespace Application.UseCases
{
    public class OrderCrudUseCase(IOrderRepository _repository, IProductRepository _productRepository) : IOrderCrudUseCase
    {
        public async Task<OrderEntity> CreateOrder(OrderRequestObject request)
        {
            OrderEntity order = new OrderEntity();

            var products = await _productRepository
                .GetByIdsAsync(request.Products);

            order.Status = OrderStatus.Pending;
            order.RegisteredAt = DateTime.UtcNow;
            order.Products = products;
            order.TotalValue = products.Sum(s => s.Price);
            order.CustomerId = request.CustomerId;
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
