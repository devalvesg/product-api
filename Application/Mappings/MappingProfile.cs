using Application.RequestObjects;
using Application.ResponseObjects;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{   
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductRequestObject, ProductEntity>();
            CreateMap<ProductEntity, ProductResponseObject>();
            CreateMap<OrderRequestObject, OrderEntity>();
            CreateMap<OrderEntity, OrderResponseObject>();
        }
    }
}
