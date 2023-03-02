namespace BeyondSports.Assessment.Domain.FootballAggregates
{
    public class Player
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public short HeightInCentimeter { get; set; }
        public DateOnly BirthDate { get; set; }

        public uint? TeamId { get; set; }
        public Team Team { get; set; }
        public List<PlayerTransfer> PlayerTransfers
        {
            get; set;

        }
    }
}
