using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection addInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
			});


            return services;
		}

    }
}

