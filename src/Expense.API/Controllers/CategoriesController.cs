using Expense.Application.Categories.CreateCategory;
using Expense.Application.Categories.GetCategories;
using Expense.Application.Categories.GetCategoryById;
using Expense.Application.DTOs.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCategoriesResult>>> Get()
    {
        var response = await sender.Send(new GetCategoriesQuery());

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCategoryByIdResult>> GetById([FromRoute] long id)
    {
        var query = new GetCategoryByIdQuery(id);
        var response = await sender.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateCategoryResult>> Create(CategoryDto categoryDto)
    {
        var command = new CreateCategoryCommand(categoryDto);
        var response = await sender.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
}