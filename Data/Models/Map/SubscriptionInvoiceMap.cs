using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class SubscriptionInvoiceMap : IEntityTypeConfiguration<SubscriptionInvoice>
    {
        public void Configure(EntityTypeBuilder<SubscriptionInvoice> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.DayCount).HasColumnType("int");
            builder.Property(q => q.CreationDate).HasColumnType("datatime2(7)");
            builder.Property(q => q.TotalAmount).HasColumnType("decimal(18,0)");
            builder.Property(q => q.TotalTerms).HasColumnType("decimal(18,0)");
            builder.Property(q => q.PayableAmount).HasColumnType("decimal(18,0)");
            builder.Property(q => q.StartDate).HasColumnType("datatime2(7)");
            builder.Property(q => q.EndDate).HasColumnType("datatime2(7)").IsRequired(false);
            builder.Property(q => q.SubscriptionTypeDescription).IsRequired(false).IsUnicode();
            builder.Property(q => q.SubscriptionTypeTitle).IsUnicode();
            builder.HasOne(q => q.User)
                .WithMany(q => q.SubscriptionInvoices)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.PermitGeneration)
                .WithMany(q => q.SubscriptionInvoice)
                .HasForeignKey(q => q.PermitGenerationId )
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
