using Api.Rest.Dto;
using Api.Rest.Features.Product.Query;
using Api.Rest.IServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Rest.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;
        public readonly IProductService  _service;
        public ProductController(IProductService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var response = await _mediator.Send(new QueryProductGetAllRequest());
            if (!response.Success)
                return BadRequest(response.Exception);

            return Ok(response.Result);

            //return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto dto)
        {
            var result = _service.Create(dto);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDto dto)
        {

            var result = _service.Update(id,dto);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {

            var result = _service.Delete(id);
            return Ok(result);
        }
    }
}

