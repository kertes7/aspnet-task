using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Web.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectsController(IProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectDto>>> GetAll([FromQuery] string? search, CancellationToken cancellationToken)
    {
        return Ok(await _service.GetAllAsync(search, cancellationToken));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProjectDto>> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var project = await _service.GetByIdAsync(id, cancellationToken);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> Create([FromBody] CreateProjectDto dto, CancellationToken cancellationToken)
    {
        var created = await _service.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProjectDto>> Update([FromRoute] int id, [FromBody] UpdateProjectDto dto, CancellationToken cancellationToken)
    {
        var updated = await _service.UpdateAsync(id, dto, cancellationToken);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        return await _service.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
    }
}
