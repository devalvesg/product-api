using Application.Contracts.UseCases;
using Application.RequestObjects;
using Application.ResponseObjects;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(ILogger<OrderController> logger, IOrderCrudUseCase _useCase, IChangeOrderStatusToCancelledUseCase _changeOrderToCancelled, IConsultOrderStatusUseCase _consultOrderStatusUseCase, IMapper _mapper) : ControllerBase
    {

        [HttpGet("/{orderId}")]
        public async Task<ActionResult> GetOrderById([FromRoute] string orderId)
        {
            return Ok(_mapper.Map<OrderResponseObject>(await _useCase.GetOrderById(orderId)));
        }

        [HttpGet("/customer/{customerId}")]
        public async Task<ActionResult> GetOrdersByCustomer([FromRoute] string customerId)
        {
            return Ok(_mapper.Map<OrderResponseObject>(await _useCase.GetOrdersByCustomer(customerId)));
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderRequestObject order)
        {
            var orderEntity = await _useCase.CreateOrder(_mapper.Map<OrderEntity>(order));
            return Ok(_mapper.Map<OrderResponseObject>(orderEntity));
        }
        
        [HttpPatch("/cancel-order/{orderId}")]
        public async Task<ActionResult> ChangeOrderStatusToCancelled([FromRoute] string orderId)
        {
            var order = await _changeOrderToCancelled.ChangeOrderStatusToCancelled(orderId);
            return Ok(_mapper.Map<OrderResponseObject>(order));
        }

        [HttpGet("/consult-status/{orderId}")]
        public async Task<ActionResult> ConsultOrderStatus([FromRoute] string orderId)
        {
            return Ok(_mapper.Map<OrderResponseObject>(await _consultOrderStatusUseCase.ConsultOrderStatus(orderId)));
        }
    }
}
