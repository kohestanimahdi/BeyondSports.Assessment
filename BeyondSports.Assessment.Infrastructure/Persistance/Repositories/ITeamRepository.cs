using BeyondSports.Assessment.Domain.FootballAggregates;

namespace BeyondSports.Assessment.Infrastructure.Persistance.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Player>> GetPlayersOfTeamAsync(uint teamId, CancellationToken cancellationToken = default);
    }
}