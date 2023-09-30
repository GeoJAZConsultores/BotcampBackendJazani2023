using System.Reflection;
using Jazani.Application.Admins.Services;
using Jazani.Application.Admins.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Jazani.Application.Cores.Contexts
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());


			services.AddTransient<IOfficeService, OfficeService>();


            return services;
		}

    }
}

