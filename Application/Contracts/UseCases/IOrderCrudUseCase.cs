﻿using Application.Enums;
using Application.RequestObjects;
using Domain.Entities;

namespace Application.Contracts.UseCases
{
    public interface IOrderCrudUseCase
    {
        Task<List<OrderEntity>> GetOrdersByCustomer(string customerId);
        Task<OrderEntity?> GetOrderById(string orderId);
        Task<OrderEntity> CreateOrder(OrderRequestObject order);
    }
}
