using Clean.Application.Interfaces;
using Clean.Application.Mappings;
using Clean.Application.Services;
using Clean.Domain.Interfaces;
using Clean.Infrastructure.Data.EntityFramework.Context;
using Clean.Infrastructure.Data.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.OData;
using Clean.Infrastructure.Data.OData;
using Microsoft.AspNetCore.OData.NewtonsoftJson;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Clean.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
                    this IServiceCollection services,
                    IConfiguration configuration,
                    IWebHostEnvironment currentEnvironment)
        {
            if (currentEnvironment.IsEnvironment("IntegrationTest"))
            {
                services.AddDbContext<CleanContext>(options =>
                    options.UseInMemoryDatabase("TestDB"));
            }
            else { 
                services.AddDbContext<CleanContext>(
               context => {
                   context.UseSqlServer(configuration.GetConnectionString("Default"));
                   context.EnableSensitiveDataLogging(); //Enable Log in Entity Framework
                 });
            }

              

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile)
                );

            return services;
        }

        public static IServiceCollection AddControllersWithOdata(this IServiceCollection services)
        {
            services.AddControllers()
                .AddOData(opt =>
                            opt.Expand()
                            .Select()
                            .Count()
                            .OrderBy()
                            .Filter()
                            .SetMaxTop(null)
                            .AddRouteComponents("api", EdmModelConfiguration.GetEdmModel())
                        )
                .AddODataNewtonsoftJson();

            return services;
        }

    }
}
