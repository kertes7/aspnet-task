using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Web.Pages.Tasks;

public class EditModel : PageModel
{
    private readonly IWorkTaskService _service;

    public EditModel(IWorkTaskService service)
    {
        _service = service;
    }

    [BindProperty]
    public UpdateWorkTaskDto Input { get; set; } = new();

    public int Id { get; private set; }

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken cancellationToken)
    {
        var task = await _service.GetByIdAsync(id, cancellationToken);
        if (task is null)
        {
            return NotFound();
        }

        Id = id;
        Input = new UpdateWorkTaskDto
        {
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            DueDate = task.DueDate,
            ProjectId = task.ProjectId,
            AssigneeId = task.AssigneeId
        };
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id, CancellationToken cancellationToken)
    {
        Id = id;
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var updated = await _service.UpdateAsync(id, Input, cancellationToken);
        return updated is null ? NotFound() : RedirectToPage("Details", new { id });
    }
}
