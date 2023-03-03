using BeyondSports.Assessment.Application.DomainServices.Common.Dtos;

namespace BeyondSports.Assessment.Application.DomainServices.TeamServices
{
    public interface ITeamService
    {
        Task AssignPlayerToTeamAsync(uint teamId, uint playerId, CancellationToken cancellationToken = default);
        Task<List<PlayerResponseDto>> GetPlayersOfTeamAsync(uint teamId, CancellationToken cancellationToken = default);
        Task<List<TeamResponseDto>> GetTeamsAsync(CancellationToken cancellationToken = default);
    }
}