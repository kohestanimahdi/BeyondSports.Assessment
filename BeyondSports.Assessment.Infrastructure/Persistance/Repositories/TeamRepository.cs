using BeyondSports.Assessment.Domain.FootballAggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Infrastructure.Persistance.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<List<Player>> GetPlayersOfTeamAsync(uint teamId, CancellationToken cancellationToken = default)
            => _dbContext.Players.Where(i => i.TeamId == teamId).ToListAsync(cancellationToken);
    }
}
