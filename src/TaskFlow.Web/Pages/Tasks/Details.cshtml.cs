using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Web.Pages.Tasks;

public class DetailsModel : PageModel
{
    private readonly IWorkTaskService _service;

    public DetailsModel(IWorkTaskService service)
    {
        _service = service;
    }

    public WorkTaskDto? TaskItem { get; private set; }

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken cancellationToken)
    {
        TaskItem = await _service.GetByIdAsync(id, cancellationToken);
        return TaskItem is null ? NotFound() : Page();
    }
}
