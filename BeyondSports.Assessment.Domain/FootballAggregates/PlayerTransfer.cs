namespace BeyondSports.Assessment.Domain.FootballAggregates
{
    public class PlayerTransfer
    {
        public uint Id { get; set; }
        public DateTime Time { get; set; }
        public ulong Fee { get; set; }

        public uint PlayerId { get; set; }
        public uint? FromTeamId { get; set; }
        public uint? ToTeamId { get; set; }

        public Player Player { get; set; }
        public Team FromTeam { get; set; }
        public Team ToTeam { get; set; }
    }
}
