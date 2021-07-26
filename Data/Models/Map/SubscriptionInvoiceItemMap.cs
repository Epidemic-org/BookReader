using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class SubscriptionInvoiceItemMap : IEntityTypeConfiguration<SubscriptionInvoiceItem>
    {
        public void Configure(EntityTypeBuilder<SubscriptionInvoiceItem> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasOne(q => q.Product)
                .WithMany(q => q.SubscriptionInvoiceItems)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.ProductCategory)
                .WithMany(q => q.SubscriptionInvoiceItems)
                .HasForeignKey(q => q.ProductCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.SubscriptionInvoice)
                .WithMany(q => q.SubscriptionInvoiceItems)
                .HasForeignKey(q => q.SubscriptionInvoiceId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
