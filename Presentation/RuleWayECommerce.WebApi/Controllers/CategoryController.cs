using MediatR;
using Microsoft.AspNetCore.Mvc;
using RuleWayECommerce.Application.Features.Category.Commands;
using RuleWayECommerce.Application.Features.Category.Queries;

namespace RuleWayECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController (IMediator _mediator)
        : ControllerBase
    {
        [HttpGet("category-list")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(result);
        }

        [HttpGet("get-category-by-{id}")]
        public async Task<IActionResult> GetByIdCategory([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetByIdCategoryQuery(id));

            if (result is null)
                return NotFound("Category not found.");

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (result is null)
                return NotFound("Category not found.");

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand
            {
                Id = id
            });

            if (!result)
                return NotFound("Category not found.");

            return Ok("Category deleted successfully.");
        }
    }
}