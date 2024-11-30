using Expense.Application.DTOs.Outlays;
using Expense.Application.Outlays.CreateOutlay;
using Expense.Application.Outlays.GetOutlayById;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<GetOutlayByIdResult>> GetById([FromRoute] long id)
    {
        var query = new GetOutlayByIdQuery(id);
        var response = await sender.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateOutlayResult>> Create([FromBody] OutlayDto outlayDto)
    {
        var command = new CreateOutlayCommand(outlayDto);
        var response = await sender.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
}