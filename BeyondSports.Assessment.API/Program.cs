
using BeyondSports.Assessment.API.Configuration;
using BeyondSports.Assessment.Infrastructure.Persistance;

namespace BeyondSports.Assessment.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.WithSwagger();

            builder.Services.WithDbContext(builder.Configuration);

            builder.Services.WithUnitOfWorks();

            builder.Services.WithDataInitializerServices();

            builder.Services.WithDomainServices();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
    }
}