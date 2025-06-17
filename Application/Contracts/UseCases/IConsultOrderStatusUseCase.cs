using Application.Enums;
using Domain.Entities;

namespace Application.Contracts.UseCases
{
    public interface IConsultOrderStatusUseCase
    {
        Task<string> ConsultOrderStatus(string orderId);
    }
}
