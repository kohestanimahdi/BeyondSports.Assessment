using BeyondSports.Assessment.Domain.FootballAggregates;

namespace BeyondSports.Assessment.Infrastructure.Persistance.Repositories
{
    public interface ITeamRepository
    {
        void AddRangeTeams(List<Team> teams);
        Task<List<Player>> GetPlayersOfTeamAsync(uint teamId, CancellationToken cancellationToken = default);
        Task<List<Team>> GetTeamsAsync(CancellationToken cancellationToken = default);
        bool IsAnyTeamExists();
    }
}