using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class InvoiceTermMap : IEntityTypeConfiguration<InvoiceTerm>
    {
        public void Configure(EntityTypeBuilder<InvoiceTerm> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(s => s.Invoice)
           .WithMany(g => g.InvoiceTerms)
           .HasForeignKey(s => s.InvoiceId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.TermType)
           .WithMany(g => g.InvoiceTerms)
           .HasForeignKey(s => s.TermTypeId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.TermAmount).IsRequired(true).HasPrecision(18, 2);

        }
    }
}
