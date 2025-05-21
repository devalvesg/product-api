using Application.Contracts.UseCases;
using Application.RequestObjects;
using Application.ResponseObjects;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ILogger<ProductController> logger, IProductUseCase _useCase, IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(_mapper.Map<List<ProductResponseObject>>(await _useCase.GetProducts()));
        }

        [HttpGet("/{productId}")]
        public async Task<ActionResult> GetProductsById([FromRoute] string productId)
        {
            return Ok(_mapper.Map<ProductResponseObject>(await _useCase.GetProducts()));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductRequestObject)
        {
            return Ok(_mapper.Map<ProductResponseObject>(await _useCase.GetProducts()));
        }

        [HttpDelete("/{productId}")]
        public async Task<ActionResult> DeleteProduct(string productId)
        {
            return Ok(_mapper.Map<ProductResponseObject>(await _useCase.GetProducts()));
        }
    }
}
