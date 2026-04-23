using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Web.Pages.Tasks;

public class CreateModel : PageModel
{
    private readonly IWorkTaskService _service;

    public CreateModel(IWorkTaskService service)
    {
        _service = service;
    }

    [BindProperty]
    public CreateWorkTaskDto Input { get; set; } = new() { ProjectId = 1, AssigneeId = 1 };

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _service.CreateAsync(Input, "razor-ui", cancellationToken);
        return RedirectToPage("Index");
    }
}
