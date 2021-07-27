using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class CampaingnMap : IEntityTypeConfiguration<Campaingn>
    {
        public void Configure(EntityTypeBuilder<Campaingn> builder)
        {

            builder.HasKey(f => f.Id);

            builder.Property(d => d.Title).IsRequired(true).HasMaxLength(75).IsUnicode(true);

            builder.Property(d => d.StartDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired(true);

            builder.Property(d => d.EndDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired(false);

            builder.Property(d => d.CreationDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired(true);

            builder.HasOne(s => s.Admin)
            .WithMany(g => g.Campaingns)
            .HasForeignKey(s => s.AdminId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.AmountType).IsRequired(true).HasColumnType("tinyint");

            builder.Property(d => d.AmountValue).IsRequired(true).HasColumnType("decimal").HasPrecision(18, 2);
            builder.Property(d => d.IsActive).IsRequired(true).HasColumnType("bit");

        
        }
    }
}
