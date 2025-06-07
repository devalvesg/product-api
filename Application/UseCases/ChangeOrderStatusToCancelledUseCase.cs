using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.Enums;
using Application.Exceptions;
using Domain.Entities;

namespace Application.UseCases
{
    public class ChangeOrderStatusToCancelledUseCase(IOrderRepository _repository) : IChangeOrderStatusToCancelledUseCase
    {
        public async Task<OrderEntity> ChangeOrderStatusToCancelled(string orderId)
        {
            var order = await _repository.GetByIdAsync(orderId) ?? throw new CustomException("Order not found");

            if(order.Status == OrderStatus.Confirmed)
            {
                throw new CustomException("Order status cannot be change because the order already has been confirmed");
            }

            return await _repository.ChangeOrderStatusToCancelled(order);
        }
    }
}
