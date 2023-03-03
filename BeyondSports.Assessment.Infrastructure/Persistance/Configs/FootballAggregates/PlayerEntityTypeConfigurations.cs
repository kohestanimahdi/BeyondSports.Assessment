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
    internal class PlayerEntityTypeConfigurations : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Name).IsRequired(true).HasMaxLength(100);
            builder.HasOne(i => i.Team).WithMany(i => i.Players).HasForeignKey(i => i.TeamId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(i => i.PlayerTransfers).WithOne(i => i.Player).HasForeignKey(i => i.PlayerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
