using Microsoft.Extensions.DependencyInjection;

namespace Scheduler.Core.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		services.AddMediatR(x => 
			x.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions)));
		
		return services;
	}
}