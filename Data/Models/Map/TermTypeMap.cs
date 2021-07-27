using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class TermTypeMap : IEntityTypeConfiguration<TermType>
    {
        public void Configure(EntityTypeBuilder<TermType> builder) {

            builder.HasKey(t => t.Id);
            builder.Property(d => d.Title).HasMaxLength(50).IsRequired(true).IsUnicode(true);           
            builder.Property(t => t.TermValue).IsRequired(true).HasColumnType("decimal").HasPrecision(18, 2);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");
            builder.HasOne(t => t.Admin)
               .WithMany(u => u.TermTypes)
               .HasForeignKey(t => t.AdminId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.NoAction)
               ;
        }
    }
}
