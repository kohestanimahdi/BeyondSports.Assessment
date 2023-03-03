using BeyondSports.Assessment.Domain.FootballAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Assessment.Infrastructure.Persistance.Configs.FootballAggregates
{
    internal class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Title).IsRequired(true).HasMaxLength(100);
            builder.HasMany(i => i.PlayerInTransfers).WithOne(i => i.ToTeam).HasForeignKey(i => i.ToTeamId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(i => i.PlayerOutTransfers).WithOne(i => i.FromTeam).HasForeignKey(i => i.FromTeamId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
