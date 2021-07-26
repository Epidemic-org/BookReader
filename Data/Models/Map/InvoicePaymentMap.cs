using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class InvoicePaymentMap : IEntityTypeConfiguration<InvoicePayment>
    {
        public void Configure(EntityTypeBuilder<InvoicePayment> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(s => s.Invoice)
           .WithMany(g => g.invoicePayments)
           .HasForeignKey(s => s.InvoiceId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.PayAmount).IsRequired(true).HasPrecision(18, 0);

            builder.HasOne(s => s.Transaction)
           .WithMany(g => g.InvoicePayments)
           .HasForeignKey(s => s.TransactionId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.CreationDate).IsRequired(true).HasMaxLength(7).HasColumnType("datetime2");

        }
    }
}
