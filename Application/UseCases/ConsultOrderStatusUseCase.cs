using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.Enums;

namespace Application.UseCases
{
    public class ConsultOrderStatusUseCase(IOrderRepository _repository) : IConsultOrderStatusUseCase
    {
        public async Task<OrderStatus> ConsultOrderStatus(string orderId)
        {
            return await _repository.ConsultOrderStatus(orderId);
        }
    }
}
