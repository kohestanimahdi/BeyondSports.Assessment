
using BeyondSports.Assessment.API.Configuration;
using BeyondSports.Assessment.API.Configuration.Middlewares;
using BeyondSports.Assessment.Infrastructure.Persistance;

namespace BeyondSports.Assessment.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.WithSwagger();

            builder.Services.WithDbContext(builder.Configuration);

            builder.Services.WithUnitOfWorks();

            builder.Services.WithDataInitializerServices();

            builder.Services.WithDomainServices();

            var app = builder.Build();

            app.IntializeDatabase();

            app.WithCustomExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
    }
}