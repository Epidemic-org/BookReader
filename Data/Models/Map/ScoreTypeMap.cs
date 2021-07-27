using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Data.Models.Map
{
    public class ScoreTypeMap : IEntityTypeConfiguration<ScoreType>
    {
        public void Configure(EntityTypeBuilder<ScoreType> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Admin)
                .WithMany(s => s.ScoreTypes)
                .HasForeignKey(d => d.AdminId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.Title).IsRequired().IsUnicode();
            builder.Property(d => d.ScoreValue).IsRequired().IsUnicode();
            builder.Property(d => d.IsActive).IsRequired().IsUnicode().HasColumnType("bit");
            builder.Property(d => d.ActionType).IsRequired().HasColumnType("tinyint");
            builder.Property(d => d.CreationDate).IsRequired().IsUnicode().HasColumnType("datetime2").HasMaxLength(7);
            builder.Property(d => d.MinAmount).IsUnicode().HasPrecision(18,0);
            builder.Property(d => d.StartDate).IsUnicode().HasColumnType("datetime2").HasMaxLength(7);
            builder.Property(d => d.EndDate).IsUnicode().HasColumnType("datetime2").HasMaxLength(7);
        }
    }
}
