using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class InvoiceTermsMap : IEntityTypeConfiguration<InvoiceTerm>
    {
        public void Configure(EntityTypeBuilder<InvoiceTerm> builder)
        {
            builder.HasKey(f => f.Id);
            //foreignkey invoiceid
            //foreignkey term typeid
            builder.Property(d => d.TermAmount).IsRequired(true).HasPrecision(18, 2);

        }
    }
}
