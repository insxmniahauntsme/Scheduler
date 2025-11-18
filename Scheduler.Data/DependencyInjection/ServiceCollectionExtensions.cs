using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Data.Interfaces;
using Scheduler.Data.Models;
using Scheduler.Data.Repositories;
using TaskStatus = Scheduler.Data.Models.TaskStatus;

namespace Scheduler.Data.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<SchedulerDbContext>(opt =>
			opt.UseNpgsql(connectionString, npgsqlOptions =>
			{
				npgsqlOptions.MapEnum<TaskStatus>();
				npgsqlOptions.MapEnum<TaskPriority>();
			}));

		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<ITaskRepository, TaskRepository>();
		
		return services;
	}
}