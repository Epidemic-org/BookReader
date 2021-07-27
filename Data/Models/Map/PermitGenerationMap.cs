using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Data.Models.Map
{
    public class PermitGenerationMap : IEntityTypeConfiguration<PermitGeneration>
    {
        public void Configure(EntityTypeBuilder<PermitGeneration> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(e => e.Amount).HasPrecision(18,2);

            builder.Property(e => e.PermitCode).IsRequired();

            builder.HasOne(d => d.Permit)
                .WithMany(p => p.PermitGenerations)
                .HasForeignKey(d => d.PermitId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.User)
                .WithMany(p => p.PermitGenerations)
                .HasForeignKey(d => d.UserId)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
