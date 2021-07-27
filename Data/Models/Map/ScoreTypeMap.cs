using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ScoreTypeMap : IEntityTypeConfiguration<ScoreType>
    {
        public void Configure(EntityTypeBuilder<ScoreType> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Title).IsUnicode();
            builder.Property(q => q.ScoreValue).HasColumnType("int");
            builder.Property(q => q.IsActive).HasColumnType("bit");
            builder.Property(q => q.ActionType).HasColumnType("tinyint");
            builder.Property(q => q.CreationDate).HasColumnType("datetime2(7)");
            builder.Property(q => q.MinAmount).HasColumnType("decimal(18,0)").IsRequired(false);
            builder.Property(q => q.StartDate).HasColumnType("datetime2(7)").IsRequired(false);
            builder.Property(q => q.EndDate).HasColumnType("datetime2(7)").IsRequired(false);
            builder.HasOne(q => q.Admin)
                .WithMany(q => q.ScoreTypes)
                .HasForeignKey(q => q.AdminId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
