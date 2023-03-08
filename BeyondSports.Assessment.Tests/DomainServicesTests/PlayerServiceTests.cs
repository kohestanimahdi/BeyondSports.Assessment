using BeyondSports.Assessment.Application.DomainServices.PlayerServices;
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
        public async Task GetPlayerAsync_NotFoundException()
        {
            _mockPlayerRepository.Setup(i => i.GetPlayerAsync(It.IsAny<uint>(), It.IsAny<CancellationToken>())).ReturnsAsync(default(Player));

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await _playerService.GetPlayerAsync(1, CancellationToken.None));

            Assert.Equal("Player is not found", exception.Message);
        }
    }
}
