using MediatR;
using Microsoft.AspNetCore.Mvc;
using RuleWayECommerce.Application.Features.Category.Commands;
using RuleWayECommerce.Application.Features.Category.Queries;

namespace RuleWayECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(Guid id)
        {
            var result = await _mediator.Send(new GetByIdCategoryQuery(id));

            if (result is null)
                return NotFound("Category not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (result is null)
                return NotFound("Category not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
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