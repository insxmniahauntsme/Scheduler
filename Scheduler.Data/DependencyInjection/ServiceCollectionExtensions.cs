using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Data.Interfaces;
using Scheduler.Data.Repositories;

namespace Scheduler.Data.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<SchedulerDbContext>(opt =>
			opt.UseNpgsql(connectionString));

		services.AddScoped<IUserRepository, UserRepository>();
		
		return services;
	}
}