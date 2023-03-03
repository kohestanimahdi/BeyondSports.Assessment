using BeyondSports.Assessment.Application.DomainServices.Common.Dtos;
using BeyondSports.Assessment.Application.DomainServices.PlayerServices.Models;
using BeyondSports.Assessment.Domain.Exceptions;
using BeyondSports.Assessment.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Application.DomainServices.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerReporitory _playerReporitory;

        public PlayerService(IPlayerReporitory playerReporitory)
        {
            _playerReporitory = playerReporitory;
        }

        public async Task<PlayerResponseDto> GetPlayerAsync(uint id, CancellationToken cancellationToken = default)
        {
            var player = await _playerReporitory.GetPlayerAsync(id, cancellationToken);
            if (player is null)
                throw new NotFoundException("Player is not found");

            return new PlayerResponseDto(player);
        }

        public async Task<PlayerResponseDto> CreatePlayerAsync(AddPlayerRequestDto requestDto, CancellationToken cancellationToken = default)
        {
            var player = requestDto.MapToPlayer();
            await _playerReporitory.AddPlayerAsync(player, cancellationToken);

            return new PlayerResponseDto(player);
        }

        public async Task UpdatePlayerAsync(UpdatePlayerRequestDto requestDto, CancellationToken cancellationToken = default)
        {
            var player = await _playerReporitory.GetPlayerAsync(requestDto.Id, cancellationToken);
            if (player is null)
                throw new NotFoundException("Player is not found");


            player.HeightInCentimeter = requestDto.HeightInCentimeter;
            player.BirthDate = requestDto.BirthDate;
            player.Name = requestDto.Name;

            await _playerReporitory.UpdatePlayerAsync(player, cancellationToken);
        }
    }
}
