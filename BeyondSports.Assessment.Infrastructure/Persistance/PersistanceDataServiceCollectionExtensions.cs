using BeyondSports.Assessment.Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Infrastructure.Persistance
{
    public static class PersistanceDataServiceCollectionExtensions
    {
        public static IServiceCollection WithReporitories(this IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();

            return services;
        }
    }
}
