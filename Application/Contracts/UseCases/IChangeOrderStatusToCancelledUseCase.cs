using Application.Enums;
using Domain.Entities;

namespace Application.Contracts.UseCases
{
    public interface IChangeOrderStatusToCancelledUseCase
    {
        Task<OrderEntity> ChangeOrderStatusToCancelled(string orderId);
    }
}
