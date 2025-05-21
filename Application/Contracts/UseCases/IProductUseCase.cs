using Domain.Entities;

namespace Application.Contracts.UseCases
{
    public interface IProductUseCase
    {
        Task<List<ProductEntity>> GetProducts();
    }
}
