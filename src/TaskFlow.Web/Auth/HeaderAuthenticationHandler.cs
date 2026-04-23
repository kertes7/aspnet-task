using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace TaskFlow.Web.Auth;

public class HeaderAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public HeaderAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue("X-Demo-User", out var user))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        var role = Request.Headers.TryGetValue("X-Demo-Role", out var roleHeader) ? roleHeader.ToString() : "Member";
        var department = Request.Headers.TryGetValue("X-Demo-Department", out var departmentHeader)
            ? departmentHeader.ToString()
            : "Student";

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.ToString()),
            new Claim(ClaimTypes.Email, user.ToString()),
            new Claim(ClaimTypes.Role, role),
            new Claim("department", department)
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(identity), Scheme.Name)));
    }
}
