using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ScoreLogMap : IEntityTypeConfiguration<ScoreLog>
    {
        public void Configure(EntityTypeBuilder<ScoreLog> builder)
        {
            builder.Property(e => e.Id);
            

            builder.HasOne(d => d.ScoreType)
                        .WithMany(p => p.ScoreLogs)
                        .HasForeignKey(d => d.ScoreId).IsRequired()
                        .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.User)
                        .WithMany(p => p.ScoreLogs)
                        .HasForeignKey(d => d.UserId).IsRequired()
                        .OnDelete(DeleteBehavior.NoAction);
            builder.Property(e => e.Description).HasMaxLength(300);
            builder.Property(e => e.CreationDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired();
            builder.Property(e => e.ScoreValue).IsRequired();

        }
    }
}
