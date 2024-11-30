using Expense.Application.Outlays.GetOutlays;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Controllers;

[Route("api/outlays")]
[ApiController]
public class OutlaysController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetOutlaysResult>> Get()
    {
        var response = await sender.Send(new GetOutlaysQuery());

        return Ok(response);
    }
}