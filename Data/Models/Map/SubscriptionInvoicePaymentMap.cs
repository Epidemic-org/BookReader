using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class SubscriptionInvoicePaymentMap : IEntityTypeConfiguration<SubscriptionInvoicePayment>
    {
        public void Configure(EntityTypeBuilder<SubscriptionInvoicePayment> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.CreationDate).HasColumnType("datetime2(7)");
            builder.Property(q => q.PayAmount).HasColumnType("decimal(18,0)");
            builder.HasOne(q => q.Transaction)
                .WithMany(q => q.SubscriptionInvoicePayments)
                .HasForeignKey(q => q.TransactionId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.SubscriptionInvoice)
                .WithMany(q => q.SubscriptionInvoicePayments)
                .HasForeignKey(q => q.SubscriptionInvoiceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
