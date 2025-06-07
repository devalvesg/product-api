using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.Enums;
using Domain.Entities;

namespace Application.UseCases
{
    public class ChangeOrderStatusToCancelledUseCase(IOrderRepository _repository) : IChangeOrderStatusToCancelledUseCase
    {
        public Task<OrderEntity> ChangeOrderStatusToCancelled(string orderId)
        {
            return Task.FromResult(new OrderEntity());
        }
    }
}
