using BeyondSports.Assessment.Domain.FootballAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Application.DomainServices.PlayerServices.Models
{
    public class AddPlayerRequestDto
    {
        public string Name { get; set; }
        public short HeightInCentimeter { get; set; }
        public DateOnly BirthDate { get; set; }

        public Player MapToPlayer() => new()
        {
            Name = Name,
            BirthDate = BirthDate,
            HeightInCentimeter = HeightInCentimeter,
        };
    }
}
