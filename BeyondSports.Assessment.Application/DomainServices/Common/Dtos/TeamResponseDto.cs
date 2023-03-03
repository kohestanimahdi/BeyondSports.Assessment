using BeyondSports.Assessment.Domain.FootballAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Application.DomainServices.Common.Dtos
{
    public class TeamResponseDto
    {
        public uint Id { get; set; }
        public string Title { get; set; }

        public TeamResponseDto(Team team)
        {
            Id = team.Id;
            Title = team.Title;
        }
    }
}
