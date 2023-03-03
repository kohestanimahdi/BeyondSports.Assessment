using BeyondSports.Assessment.API.Configuration.Filters;
using BeyondSports.Assessment.API.Models.RequestModels;
using BeyondSports.Assessment.Application.DomainServices.Common.Dtos;
using BeyondSports.Assessment.Application.DomainServices.TeamServices;
using BeyondSports.Assessment.Domain.Common;
using BeyondSports.Assessment.Domain.FootballAggregates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeyondSports.Assessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// get the list of the teams
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<List<TeamResponseDto>>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> GetTeamsAsync(CancellationToken cancellationToken = default)
        {
            var teams = await _teamService.GetTeamsAsync(cancellationToken);

            return Ok(teams);
        }


        /// <summary>
        /// get the list of the players of specific team
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{teamId}/Players")]
        [ProducesResponseType(typeof(ApiResult<List<PlayerResponseDto>>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> GetPlayersOfTeamAsync([FromRoute] uint teamId, CancellationToken cancellationToken = default)
        {
            var players = await _teamService.GetPlayersOfTeamAsync(teamId, cancellationToken);

            return Ok(players);
        }

        /// <summary>
        /// assign a player who has no team to a team
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("AssignPlayer")]
        [ProducesResponseType(typeof(ApiResult), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> AssignPlayerToTeamAsync([FromBody] AssignPlayerToTeamRequestModel requestModel, CancellationToken cancellationToken = default)
        {
            await _teamService.AssignPlayerToTeamAsync(requestModel.TeamId, requestModel.PlayerId, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// unassign a player from a team
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("UnAssignPlayer")]
        [ProducesResponseType(typeof(ApiResult), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> UnAssignPlayerFromTeamAsync([FromBody] AssignPlayerToTeamRequestModel requestModel, CancellationToken cancellationToken = default)
        {
            await _teamService.UnAssignPlayerFromTeamAsync(requestModel.TeamId, requestModel.PlayerId, cancellationToken);

            return Ok();
        }
    }
}
