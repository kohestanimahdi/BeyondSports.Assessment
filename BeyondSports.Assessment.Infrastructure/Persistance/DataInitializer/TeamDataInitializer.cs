using BeyondSports.Assessment.Domain.FootballAggregates;
using BeyondSports.Assessment.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Infrastructure.Persistance.DataInitializer
{
    public class TeamDataInitializer : IDataInitializer
    {
        private readonly ITeamRepository _teamRepository;

        public TeamDataInitializer(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public void InitializeData()
        {
            if (_teamRepository.IsAnyTeamExists())
                return;

            var teams = new List<Team>()
            {
                new Team
                {
                    Title = "Real Madrid",
                    Players = new List<Player>
                    {
                        new Player
                        {
                            Name = "Karim Benzema",
                            HeightInCentimeter = 185,
                            BirthDate =  new DateOnly(1987,12,19)
                        },
                        new Player
                        {
                            Name = "Federico Valverde",
                            HeightInCentimeter = 182,
                            BirthDate =  new DateOnly(1998,07,22)
                        },
                        new Player
                        {
                            Name = "Toni Kroos",
                            HeightInCentimeter = 183,
                            BirthDate =  new DateOnly(1990,01,4)
                        },
                        new Player
                        {
                            Name = "Luka Modric",
                            HeightInCentimeter = 172,
                            BirthDate =  new DateOnly(1985,09,9)
                        }
                    }
                },
                new Team
                {
                    Title = "Real Madrid",
                    Players = new List<Player>
                    {
                        new Player
                        {
                            Name = "Raphaël Varane",
                            HeightInCentimeter = 191,
                            BirthDate =  new DateOnly(1993,04,25)
                        },
                        new Player
                        {
                            Name = "Casemiro",
                            HeightInCentimeter = 185,
                            BirthDate =  new DateOnly(1992,2,23)
                        },
                        new Player
                        {
                            Name = "David de Gea",
                            HeightInCentimeter = 189,
                            BirthDate =  new DateOnly(1990,11,7)
                        },
                        new Player
                        {
                            Name = "Marcus Rashford",
                            HeightInCentimeter = 185,
                            BirthDate =  new DateOnly(1997,10,31)
                        }
                    }
                }
            };
            _teamRepository.AddRangeTeams(teams);
        }
    }
}
