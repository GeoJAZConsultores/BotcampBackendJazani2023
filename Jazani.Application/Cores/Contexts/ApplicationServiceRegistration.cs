using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Jazani.Application.Cores.Contexts
{
    public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
		}

    }
}

