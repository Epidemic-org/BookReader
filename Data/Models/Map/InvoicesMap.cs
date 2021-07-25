using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class InvoicesMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

            builder.HasKey(f => f.Id);
            //foreignkey userid
            //foreignkey permitgenerationid
            builder.Property(d => d.TotalAmount).IsRequired(true).HasPrecision(18, 0);
            builder.Property(d => d.TotalTerms).IsRequired(true).HasPrecision(18, 2);
            builder.Property(d => d.PayableAmount).IsRequired(true).HasPrecision(18, 2);
            builder.Property(d => d.Address).IsRequired(false).IsUnicode(true);
            builder.Property(d => d.CreationDate).IsRequired(true).HasMaxLength(7).HasColumnType("datetime2");

        }
    }
}
