using MediatR;
using Microsoft.AspNetCore.Mvc;
using RuleWayECommerce.Application.Features.Product.Commands;
using RuleWayECommerce.Application.Features.Product.Queries;

namespace RuleWayECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController (IMediator _mediator)
        : ControllerBase
    {
        [HttpGet("product-list")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());

            return Ok(result);
        }

        [HttpGet("get-product-by-{id}")]
        public async Task<IActionResult> GetByIdProduct([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetByIdProductQuery(id));

            if (result is null)
                return NotFound("Product not found.");

            return Ok(result);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterProducts(
            [FromQuery] string? keyword,
            [FromQuery] int? minStock,
            [FromQuery] int? maxStock)
        {
            var result = await _mediator.Send(new FilterProductsQuery(keyword, minStock, maxStock));

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
        {
            try
            {
                command.Id = id;

                var result = await _mediator.Send(command);

                if (result is null)
                    return NotFound("Product not found.");

                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand
            {
                Id = id
            });

            if (!result)
                return NotFound("Product not found.");

            return Ok("Product deleted successfully.");
        }
    }
}