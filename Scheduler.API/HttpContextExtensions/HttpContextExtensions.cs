using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Scheduler.Api.HttpContextExtensions;

public static class HttpContextExtensions
{
	public static Guid GetUserId(this HttpContext context)
	{
		var id = context.User.FindFirstValue(ClaimTypes.NameIdentifier)
		         ?? context.User.FindFirstValue(JwtRegisteredClaimNames.Sub);

		return id is null ? Guid.Empty : Guid.Parse(id);
	}
}