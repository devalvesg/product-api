using System.ComponentModel.DataAnnotations;
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
    public class ProductController(ILogger<ProductController> logger, IProductCrudUseCase _useCase, IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(_mapper.Map<List<ProductResponseObject>>(await _useCase.GetProducts()));
        }

        [HttpGet("/{productId}")]
        public async Task<ActionResult> GetProductsById([FromRoute] string productId)
        {
            return Ok(_mapper.Map<ProductResponseObject>(await _useCase.GetProductById(productId)));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductRequestObject product)
        {
            var productResponse = await _useCase.CreateProduct(_mapper.Map<ProductEntity>(product));
            return Ok(_mapper.Map<ProductResponseObject>(productResponse));
        }

        [HttpPatch("/{productId}")]
        public async Task<ActionResult> UpdateProductName([Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")] string name, string productId)
        {
            var productResponse = await _useCase.UpdateProductName(name, productId);
            return Ok(_mapper.Map<ProductResponseObject>(productResponse));
        }

        [HttpDelete("/{productId}")]
        public async Task<ActionResult> DeleteProduct(string productId)
        {
            await _useCase.DeleteProduct(productId);
            return Ok();
        }
    }
}
