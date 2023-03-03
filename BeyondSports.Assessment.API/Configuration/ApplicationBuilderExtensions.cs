using BeyondSports.Assessment.Infrastructure.Persistance.DataInitializer;
using BeyondSports.Assessment.Infrastructure.Persistance;

namespace BeyondSports.Assessment.API.Configuration
{
    public static class ApplicationBuilderExtensions
    {
        public static void IntializeDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var dbcontext = scope.ServiceProvider.GetService<ApplicationDbContext>();
            dbcontext.Database.EnsureCreated();

            var dataInitializers = scope.ServiceProvider.GetServices<IDataInitializer>();
            foreach (var dataInitializer in dataInitializers)
                dataInitializer.InitializeData();
        }
    }
}
