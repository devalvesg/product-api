using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Domain.Entities;

namespace Application.UseCases
{
    public class ProductUseCase (IProductRepository _repository) : IProductUseCase
    {
        public async Task<List<ProductEntity>> GetProducts()
        {
            return await _repository.GetAsync();
        }
    }
}
