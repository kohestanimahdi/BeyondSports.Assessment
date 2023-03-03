using BeyondSports.Assessment.Application.DomainServices.Common.Dtos;
using BeyondSports.Assessment.Domain.Exceptions;
using BeyondSports.Assessment.Domain.FootballAggregates;
using BeyondSports.Assessment.Infrastructure.Persistance.Repositories;

namespace BeyondSports.Assessment.Application.DomainServices.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerReporitory _playerReporitory;

        public TeamService(ITeamRepository teamRepository, IPlayerReporitory playerReporitory)
        {
            _teamRepository = teamRepository;
            _playerReporitory = playerReporitory;
        }


        public async Task<List<PlayerResponseDto>> GetPlayersOfTeamAsync(uint teamId, CancellationToken cancellationToken = default)
        {
            var response = await _teamRepository.GetPlayersOfTeamAsync(teamId, cancellationToken);
            return response.ConvertAll(i => new PlayerResponseDto(i));
        }

        public async Task<List<TeamResponseDto>> GetTeamsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _teamRepository.GetTeamsAsync(cancellationToken);
            return response.ConvertAll(i => new TeamResponseDto(i));
        }

        public async Task AssignPlayerToTeamAsync(uint teamId, uint playerId, CancellationToken cancellationToken = default)
        {
            var player = await _playerReporitory.GetPlayerAsync(playerId, cancellationToken);
            if (player is null)
                throw new NotFoundException("Player is not found");

            if (player.TeamId.HasValue)
                throw new AppException(Domain.Common.ApiResultStatusCode.BadRequest, "This player is already assigned to another team");

            var team = await _teamRepository.GetTeamAsync(teamId, cancellationToken);
            if (team is null)
                throw new NotFoundException("Team is not found");

            player.TeamId = teamId;

            await _playerReporitory.UpdatePlayerAsync(player, cancellationToken);
        }
    }
}
