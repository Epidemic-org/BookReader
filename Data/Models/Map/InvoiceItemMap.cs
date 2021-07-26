using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class InvoiceItemMap : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.HasKey(f => f.Id);
            //foreignkey invoiceid
            //foreignkey productid
            builder.Property(d => d.Quantity).IsRequired(true).HasPrecision(18, 2);
            builder.Property(d => d.Price).IsRequired(true).HasPrecision(18, 0);
            builder.Property(d => d.TermAMount).IsRequired(true).HasPrecision(18, 0);
        }
    }
}
