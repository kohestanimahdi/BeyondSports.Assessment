using BeyondSports.Assessment.API.Configuration.Filters;
using BeyondSports.Assessment.API.Models.RequestModels;
using BeyondSports.Assessment.Application.DomainServices.Common.Dtos;
using BeyondSports.Assessment.Application.DomainServices.PlayerServices;
using BeyondSports.Assessment.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeyondSports.Assessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        /// <summary>
        /// get the player by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResult<PlayerResponseDto>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> GetPlayerAsync(uint id, CancellationToken cancellationToken = default)
        {
            var player = await _playerService.GetPlayerAsync(id, cancellationToken);

            return Ok(player);
        }

        /// <summary>
        /// add a player
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<PlayerResponseDto>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> AddPlayerAsync([FromBody] PlayerRequestModel request, CancellationToken cancellationToken = default)
        {
            var player = await _playerService.CreatePlayerAsync(request.MapToCreateDto(), cancellationToken);

            return Ok(player);
        }

        /// <summary>
        /// update a player
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(ApiResult<PlayerResponseDto>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePlayerAsync([FromRoute] uint id, [FromBody] PlayerRequestModel request, CancellationToken cancellationToken = default)
        {
            await _playerService.UpdatePlayerAsync(request.MapToUpdateDto(id), cancellationToken);

            return Ok();
        }
    }
}
