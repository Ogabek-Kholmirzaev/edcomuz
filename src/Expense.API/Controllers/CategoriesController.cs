using Expense.Application.Categories.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCategoriesResult>>> Get()
    {
        var response = await sender.Send(new GetCategoriesQuery());

        return Ok(response);
    }
}