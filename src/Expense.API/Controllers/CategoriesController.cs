using Expense.Application.Categories.CreateCategory;
using Expense.Application.Categories.GetCategories;
using Expense.Application.Categories.GetCategoryById;
using Expense.Application.DTOs.Categories;
using Expense.Domain.Entities.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCategoriesResult>>> Get()
    {
        var response = await sender.Send(new GetCategoriesQuery());

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById([FromRoute] ulong id)
    {
        var query = new GetCategoryByIdQuery(id);
        var response = await sender.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateCategoryResult>> Create([FromBody] CategoryDto categoryDto)
    {
        var command = new CreateCategoryCommand(categoryDto);
        var response = await sender.Send(command);

        return CreatedAtAction($"api/categories/{response.Id}", new { id = response.Id });
    }
}