using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Web.Pages.Tasks;

public class IndexModel : PageModel
{
    private readonly IWorkTaskService _service;

    public IndexModel(IWorkTaskService service)
    {
        _service = service;
    }

    public List<WorkTaskDto> Tasks { get; private set; } = new();

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        Tasks = await _service.GetAllAsync(null, cancellationToken);
    }
}
