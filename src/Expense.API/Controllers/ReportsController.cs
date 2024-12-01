using Expense.Application.Reports.GetReportsByYear;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expense.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController(ISender sender) : ControllerBase
{
    [HttpGet("year/{year:int}")]
    public async Task<ActionResult<GetReportsByYearResult>> GetByYear(int year)
    {
        var query = new GetReportsByYearQuery(year);
        var respone = await sender.Send(query);

        return Ok(respone);
    }
}
