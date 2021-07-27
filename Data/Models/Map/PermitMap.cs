using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class PermitMap : IEntityTypeConfiguration<Permit>
    {
        public void Configure(EntityTypeBuilder<Permit> builder) {
            builder.Property(t => t.Id);
            builder.Property(d => d.Title).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.PermitBaseCode).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");
            builder.Property(d => d.StartDate).HasColumnType("datetime2(7)");
            builder.Property(d => d.EndDate).HasColumnType("datetime2(7)");


            builder.HasOne(p => p.TermType)
                .WithMany(p => p.Permits)
                .HasForeignKey(p => p.TermTypeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction)
                ;

            builder.HasOne(p => p.Admin)
                .WithMany(p => p.Permits)
                .HasForeignKey(p => p.AdminId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction)
                ;

        }
    }
}
