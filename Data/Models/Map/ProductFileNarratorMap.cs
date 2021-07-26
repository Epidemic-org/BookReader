using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductFileNarratorMap : IEntityTypeConfiguration<ProductFileNarrator>
    {
        public void Configure(EntityTypeBuilder<ProductFileNarrator> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.ProductFile)
            .WithMany(s => s.ProductFileNarrators)
            .HasForeignKey(d => d.ProductFileId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Narrator)
            .WithMany(s => s.ProductFileNarrators)
            .HasForeignKey(d => d.NarratorId)
            .IsRequired(true)
          .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.ProductNarrorateWagePercent).IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
        }
    }
}
