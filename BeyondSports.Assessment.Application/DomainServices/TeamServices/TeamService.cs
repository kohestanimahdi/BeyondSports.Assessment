using BeyondSports.Assessment.Application.DomainServices.Common.Dtos;
using BeyondSports.Assessment.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Application.DomainServices.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
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
    }
}
