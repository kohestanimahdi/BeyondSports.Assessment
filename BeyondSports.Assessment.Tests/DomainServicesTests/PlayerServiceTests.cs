using BeyondSports.Assessment.Application.DomainServices.PlayerServices;
using BeyondSports.Assessment.Application.DomainServices.PlayerServices.Models;
using BeyondSports.Assessment.Domain.Common;
using BeyondSports.Assessment.Domain.Exceptions;
using BeyondSports.Assessment.Domain.FootballAggregates;
using BeyondSports.Assessment.Infrastructure.Persistance.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Tests.DomainServicesTests
{
    public class PlayerServiceTests
    {
        private readonly Mock<IPlayerReporitory> _mockPlayerRepository;
        private readonly IPlayerService _playerService;
        private List<Player> _players;
        public PlayerServiceTests()
        {
            _mockPlayerRepository = new Mock<IPlayerReporitory>();
            _playerService = new PlayerService(_mockPlayerRepository.Object);

            _players = new List<Player>()
            {
                new Player
                {
                    Id = 1,
                    Name = "Karim Benzema",
                    HeightInCentimeter = 185,
                    BirthDate =  new DateOnly(1987,12,19)
                },
                new Player
                {
                    Id = 2,
                    Name = "Federico Valverde",
                    HeightInCentimeter = 182,
                    BirthDate =  new DateOnly(1998,07,22)
                },
                new Player
                {
                    Id = 3,
                    Name = "Toni Kroos",
                    HeightInCentimeter = 183,
                    BirthDate =  new DateOnly(1990,01,4)
                },
                new Player
                {
                    Id = 4,
                    Name = "Luka Modric",
                    HeightInCentimeter = 172,
                    BirthDate =  new DateOnly(1985,09,9)
                }
            };
        }

        [Fact]
        public async Task GetPlayerAsync_Success()
        {
            var expectedPlayer = _players[0];
            _mockPlayerRepository.Setup(i => i.GetPlayerAsync(It.IsAny<uint>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedPlayer);

            var playerDto = await _playerService.GetPlayerAsync(1, CancellationToken.None);

            Assert.NotNull(playerDto);
            Assert.Equal(expectedPlayer.Id, playerDto.Id);
            Assert.Equal(expectedPlayer.Name, playerDto.Name);
            Assert.Equal(expectedPlayer.HeightInCentimeter, playerDto.HeightInCentimeter);
            Assert.Equal(DateTimeHelper.GetYears(expectedPlayer.BirthDate.ToDateTime(TimeOnly.MinValue), DateTime.Now), playerDto.Age);
        }

        [Fact]
        public async Task GetPlayerAsync_NotFoundException()
        {
            _mockPlayerRepository.Setup(i => i.GetPlayerAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(default(Player));

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await _playerService.GetPlayerAsync(1, CancellationToken.None));

            Assert.Equal("Player is not found", exception.Message);
        }

        [Fact]
        public async Task CreatePlayerAsync_Success()
        {
            var createPLayerDto = new AddPlayerRequestDto
            {
                HeightInCentimeter = 181,
                BirthDate = new DateOnly(1997, 12, 25),
                Name = "Mahdi Kouhestani"
            };

            var maxId = _players.Max(i => i.Id);
            _mockPlayerRepository.Setup(i => i.AddPlayerAsync(It.IsAny<Player>(), It.IsAny<CancellationToken>())).Callback<Player, CancellationToken>((model, _) =>
            {
                model.Id = maxId + 1;
            });

            var createdPlayer = await _playerService.CreatePlayerAsync(createPLayerDto, CancellationToken.None);

            Assert.NotNull(createdPlayer);
            Assert.Equal(maxId + 1, createdPlayer.Id);
            Assert.Equal(createPLayerDto.Name, createdPlayer.Name);
            Assert.Equal(createPLayerDto.HeightInCentimeter, createdPlayer.HeightInCentimeter);
            Assert.Equal(DateTimeHelper.GetYears(createPLayerDto.BirthDate.ToDateTime(TimeOnly.MinValue), DateTime.Now), createdPlayer.Age);
        }


        [Fact]
        public async Task UpdatePlayerAsync_Success()
        {
            var updatePLayerDto = new UpdatePlayerRequestDto
            {
                HeightInCentimeter = 181,
                BirthDate = new DateOnly(1997, 12, 25),
                Name = "Mahdi Kouhestani",
                Id = 1
            };

            var oroginModel = _players[0];
            _mockPlayerRepository.Setup(i => i.GetPlayerAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(oroginModel);

            _mockPlayerRepository.Setup(i => i.UpdatePlayerAsync(It.IsAny<Player>(), It.IsAny<CancellationToken>()))
                .Callback<Player, CancellationToken>((model, _) =>
            {
                model.BirthDate = updatePLayerDto.BirthDate;
                model.Name = updatePLayerDto.Name;
                model.HeightInCentimeter = updatePLayerDto.HeightInCentimeter;
            });

            await _playerService.UpdatePlayerAsync(updatePLayerDto, CancellationToken.None);

            Assert.Equal(updatePLayerDto.Name, oroginModel.Name);
            Assert.Equal(updatePLayerDto.HeightInCentimeter, oroginModel.HeightInCentimeter);
            Assert.Equal(updatePLayerDto.BirthDate, oroginModel.BirthDate);
        }

        [Fact]
        public async Task UpdatePlayerAsync_PlayerNotFound()
        {
            var updatePLayerDto = new UpdatePlayerRequestDto
            {
                HeightInCentimeter = 181,
                BirthDate = new DateOnly(1997, 12, 25),
                Name = "Mahdi Kouhestani",
                Id = 1
            };

            var oroginModel = _players[0];
            _mockPlayerRepository.Setup(i => i.GetPlayerAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(default(Player));

            _mockPlayerRepository.Setup(i => i.UpdatePlayerAsync(It.IsAny<Player>(), It.IsAny<CancellationToken>()))
                .Callback<Player, CancellationToken>((_, _) =>
                {
                    oroginModel.BirthDate = updatePLayerDto.BirthDate;
                    oroginModel.Name = updatePLayerDto.Name;
                    oroginModel.HeightInCentimeter = updatePLayerDto.HeightInCentimeter;
                });

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await _playerService.UpdatePlayerAsync(updatePLayerDto, CancellationToken.None));

            Assert.Equal("Player is not found", exception.Message);
        }
    }
}
