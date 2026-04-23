using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Web.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IWorkTaskService _service;

    public TasksController(IWorkTaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<WorkTaskDto>>> GetAll([FromQuery] string? search, CancellationToken cancellationToken)
    {
        return Ok(await _service.GetAllAsync(search, cancellationToken));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<WorkTaskDto>> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var task = await _service.GetByIdAsync(id, cancellationToken);
        return task is null ? NotFound() : Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<WorkTaskDto>> Create([FromBody] CreateWorkTaskDto dto, CancellationToken cancellationToken)
    {
        var actor = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
        var created = await _service.CreateAsync(dto, actor, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<WorkTaskDto>> Update([FromRoute] int id, [FromBody] UpdateWorkTaskDto dto, CancellationToken cancellationToken)
    {
        var updated = await _service.UpdateAsync(id, dto, cancellationToken);
        return updated is null ? NotFound() : Ok(updated);
    }

    [Authorize(Roles = "Admin,Manager")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        return await _service.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
    }

    [HttpGet("report/status")]
    public async Task<ActionResult<Dictionary<string, int>>> GetStatusReport(CancellationToken cancellationToken)
    {
        var report = await _service.GetStatusReportAsync(cancellationToken);
        return Ok(report.ToDictionary(item => item.Key.ToString(), item => item.Value));
    }

    [Authorize(Policy = "ProjectDepartment")]
    [HttpGet("secure/claims-demo")]
    public async Task<ActionResult<object>> ClaimsDemo(CancellationToken cancellationToken)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? "unknown";
        var department = User.FindFirst("department")?.Value ?? "unknown";
        var message = await _service.GetProtectedClaimDemoAsync(email, department, cancellationToken);
        return Ok(new { message, claims = User.Claims.Select(claim => new { claim.Type, claim.Value }) });
    }

    [HttpGet("error-demo")]
    public IActionResult ErrorDemo([FromQuery] string type = "business")
    {
        if (type == "data")
        {
            throw new InvalidOperationException("Simulated data access exception for lab demonstration.");
        }

        throw new TaskFlow.Application.Common.AppException("Simulated business rule violation.", 400);
    }
}
