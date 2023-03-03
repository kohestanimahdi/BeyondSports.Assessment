using BeyondSports.Assessment.Domain.FootballAggregates;

namespace BeyondSports.Assessment.Infrastructure.Persistance.Repositories
{
    public interface IPlayerReporitory
    {
        Task<Player> GetPlayerAsync(uint id, CancellationToken cancellationToken = default);
        Task UpdatePlayerAsync(Player player, CancellationToken cancellationToken = default);
        Task AddPlayerAsync(Player player, CancellationToken cancellationToken = default);
    }
}