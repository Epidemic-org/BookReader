using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class SubscriptionTypeItemMap : IEntityTypeConfiguration<SubscriptionTypeItem>
    {
        public void Configure(EntityTypeBuilder<SubscriptionTypeItem> builder)
        {
            builder.HasKey(q => q.Id);
            builder.HasOne(q => q.Product)
                .WithMany(q => q.SubscriptionTypeItems)
                .HasForeignKey(q => q.ProductId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.ProductCategory)
                .WithMany(q => q.SubscriptionTypeItems)
                .HasForeignKey(q => q.ProductCategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.SubscriptionType)
                .WithMany(q => q.SubscriptionTypeItems)
                .HasForeignKey(q => q.SubcriptionTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
