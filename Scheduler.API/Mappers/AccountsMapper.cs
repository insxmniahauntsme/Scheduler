using Riok.Mapperly.Abstractions;
using Scheduler.Api.Models;
using Scheduler.Core.Models.Requests;

namespace Scheduler.Api.Mappers;

[Mapper]
public static partial class AccountsMapper
{
	public static partial CreateAccountRequest ToRequest(this AddAccountModel model);
	
	public static partial LoginRequest ToRequest(this LoginModel model);
}