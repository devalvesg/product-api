using Application.Enums;
using Domain.Entities;

namespace Application.Contracts.UseCases
{
    public interface IConsultOrderStatusUseCase
    {
        Task<OrderStatus> ConsultOrderStatus(string orderId);
    }
}
