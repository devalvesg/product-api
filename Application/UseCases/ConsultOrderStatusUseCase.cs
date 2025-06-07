using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.Enums;

namespace Application.UseCases
{
    public class ConsultOrderStatusUseCase(IOrderRepository _repository) : IConsultOrderStatusUseCase
    {
        public Task<OrderStatus> ConsultOrderStatus(string orderId)
        {
            return Task.FromResult(OrderStatus.Confirmed);
        }
    }
}
