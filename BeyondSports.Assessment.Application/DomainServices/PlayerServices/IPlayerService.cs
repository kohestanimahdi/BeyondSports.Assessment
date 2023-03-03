using BeyondSports.Assessment.Application.DomainServices.Common.Dtos;

namespace BeyondSports.Assessment.Application.DomainServices.PlayerServices
{
    public interface IPlayerService
    {
        Task<PlayerResponseDto> GetPlayerAsync(uint id, CancellationToken cancellationToken = default);
    }
}