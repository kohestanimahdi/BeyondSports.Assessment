using System.Linq;

namespace BeyondSports.Assessment.Domain.FootballAggregates
{
    public class Team
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public List<Player> Players { get; set; }
        public List<PlayerTransfer> PlayerInTransfers { get; set; }
        public List<PlayerTransfer> PlayerOutTransfers { get; set; }
    }
}
