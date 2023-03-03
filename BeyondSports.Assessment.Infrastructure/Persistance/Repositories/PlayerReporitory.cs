using BeyondSports.Assessment.Domain.FootballAggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Infrastructure.Persistance.Repositories
{
    public class PlayerReporitory : IPlayerReporitory
    {
        private readonly ApplicationDbContext _dbContext;

        public PlayerReporitory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task AddPlayerAsync(Player player, CancellationToken cancellationToken = default)
        {
            _dbContext.Players.Add(player);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<Player> GetPlayerAsync(uint id, CancellationToken cancellationToken = default)
            => _dbContext.Players.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public Task UpdatePlayerAsync(Player player, CancellationToken cancellationToken = default)
        {
            _dbContext.Players.Update(player);
            return _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
