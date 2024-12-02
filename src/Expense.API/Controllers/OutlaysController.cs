using Expense.Application.DTOs.Outlays;
using Expense.Application.Outlays.CreateOutlay;
using Expense.Application.Outlays.DeleteOutlay;
using Expense.Application.Outlays.GetOutlayById;
using Expense.Application.Outlays.GetOutlays;
using Expense.Application.Outlays.UpdateOutlay;
using Expense.Application.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Controllers;

[Route("api/outlays")]
[ApiController]
public class OutlaysController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetOutlaysResult>> Get([FromQuery] GetOutlaysRequest request)
    {
        var response = await sender.Send(new GetOutlaysQuery(request));

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

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateOutlayResult>> Update(
        [FromRoute] long id,
        [FromBody] OutlayDto outlayDto)
    {
        var command = new UpdateOutlayCommand(outlayDto);
        var response = await sender.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeleteOutlayResult>> Delete([FromRoute] long id)
    {
        var command = new DeleteOutlayCommand(id);
        var response = await sender.Send(command);

        return Ok(response);
    }
}