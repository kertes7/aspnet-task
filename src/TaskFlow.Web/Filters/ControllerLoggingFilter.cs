using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskFlow.Web.Filters;

public class ControllerLoggingFilter : IActionFilter
{
    private readonly ILogger<ControllerLoggingFilter> _logger;

    public ControllerLoggingFilter(ILogger<ControllerLoggingFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Controller action started: {Action}", context.ActionDescriptor.DisplayName);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("Controller action finished: {Action}", context.ActionDescriptor.DisplayName);
    }
}
