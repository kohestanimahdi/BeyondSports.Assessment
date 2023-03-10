using BeyondSports.Assessment.Domain.Common;
using BeyondSports.Assessment.Domain.FootballAggregates;

namespace BeyondSports.Assessment.Application.DomainServices.Common.Dtos
{
    public class PlayerResponseDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public short HeightInCentimeter { get; set; }
        public int Age { get; set; }

        public PlayerResponseDto(Player player)
        {
            Id = player.Id;
            Name = player.Name;
            HeightInCentimeter = player.HeightInCentimeter;
            Age = DateTimeHelper.GetYears(player.BirthDate.ToDateTime(TimeOnly.MinValue), DateTime.Now);
        }
    }
}
