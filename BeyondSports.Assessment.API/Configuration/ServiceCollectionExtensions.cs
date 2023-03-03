using BeyondSports.Assessment.Application.DomainServices.TeamServices;
using BeyondSports.Assessment.Infrastructure.Persistance;
using BeyondSports.Assessment.Infrastructure.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BeyondSports.Assessment.API.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection WithDbContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("Default"));
            });

        public static IServiceCollection WithSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Beyond Sports Assessment API", Version = "v1" });

                var xmlFile = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetEntryAssembly().GetName().Name}.xml");
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        public static IServiceCollection WithUnitOfWorks(this IServiceCollection services)
        {
            services.AddScoped<IFootbalUnitOfWork, FootbalUnitOfWork>();
            return services;
        }

        public static IServiceCollection WithDataInitializerServices(this IServiceCollection services)
        {
            //services.AddScoped<IDataInitializer, ProductDataInitializer>();
            return services;
        }

        public static IServiceCollection WithDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamService>();

            services.WithReporitories();

            return services;
        }
    }
}
