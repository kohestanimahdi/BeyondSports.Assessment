using BeyondSports.Assessment.Domain.FootballAggregates;
using Microsoft.EntityFrameworkCore;

namespace BeyondSports.Assessment.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerTransfer> PlayerTransfers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
