using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Admins.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


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



            services.AddTransient<IOfficeRepository, OfficeRepository>();


            return services;
		}

    }
}

