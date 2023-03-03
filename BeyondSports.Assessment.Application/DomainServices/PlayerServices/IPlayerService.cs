using BeyondSports.Assessment.Application.DomainServices.Common.Dtos;
using BeyondSports.Assessment.Application.DomainServices.PlayerServices.Models;

namespace BeyondSports.Assessment.Application.DomainServices.PlayerServices
{
    public interface IPlayerService
    {
        Task UpdatePlayerAsync(UpdatePlayerRequestDto requestDto, CancellationToken cancellationToken = default);
        Task<PlayerResponseDto> CreatePlayerAsync(AddPlayerRequestDto requestDto, CancellationToken cancellationToken = default);
        Task<PlayerResponseDto> GetPlayerAsync(uint id, CancellationToken cancellationToken = default);
    }
}