using Clean.Application.Interfaces;
using Clean.Application.Services;
using Clean.Domain.Interfaces;
using Clean.Infrastructure.Data.EntityFramework.Context;
using Clean.Infrastructure.Data.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddDbContext<CleanContext>(
             context => context.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }

    }
}
