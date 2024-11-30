using Expense.Application.Categories.CreateCategory;
using Expense.Application.Categories.DeleteCategory;
using Expense.Application.Categories.GetCategories;
using Expense.Application.Categories.GetCategoryById;
using Expense.Application.Categories.UpdateCategory;
using Expense.Application.DTOs.Categories;
using Expense.Application.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetCategoriesResult>> Get([FromQuery] PaginationRequest request)
    {
        var response = await sender.Send(new GetCategoriesQuery(request));

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
    public async Task<ActionResult<CreateCategoryResult>> Create([FromBody] CategoryDto categoryDto)
    {
        var command = new CreateCategoryCommand(categoryDto);
        var response = await sender.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateCategoryResult>> Update(
        [FromRoute] long id,
        [FromBody] CategoryDto categoryDto)
    {
        if (id != categoryDto.Id)
        {
            return BadRequest();
        }

        var command = new UpdateCategoryCommand(categoryDto);
        var response = await sender.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeleteCategoryResult>> Delete([FromRoute] long id)
    {
        var command = new DeleteCategoryCommand(id);
        var response = await sender.Send(command);

        return Ok(response);
    }
}