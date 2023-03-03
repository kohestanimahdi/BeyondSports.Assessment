using BeyondSports.Assessment.Application.DomainServices.Common.Dtos;
using BeyondSports.Assessment.Application.DomainServices.TeamServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeyondSports.Assessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [Route("{teamId}/Players")]
        [ProducesResponseType(typeof(List<PlayerResponseDto>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> GetPlayersOfTeamAsync([FromRoute] uint teamId, CancellationToken cancellationToken = default)
        {
            var players = await _teamService.GetPlayersOfTeamAsync(teamId, cancellationToken);

            return Ok(players);
        }
    }
}
