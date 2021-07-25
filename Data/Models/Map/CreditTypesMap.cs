using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class CreditTypesMap : IEntityTypeConfiguration<CreditType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CreditType> builder)
        {

            builder.HasKey(f => f.Id);
            //foreignkey adminid 
            builder.Property(d => d.Title).IsRequired(true).HasMaxLength(100).IsUnicode(true);
            builder.Property(d => d.Description).IsRequired(false).IsUnicode(true).HasMaxLength(250);
            builder.Property(d => d.CreditPrice).IsRequired(true).HasPrecision(18, 0);
            builder.Property(d => d.CreditAmount).IsRequired(true).HasPrecision(18, 0);
            builder.Property(d => d.IsActive).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.CreationDate).IsRequired(true).HasColumnType("datetime2").HasMaxLength(7);

        }
    }
}
