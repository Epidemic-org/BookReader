using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductPublisherMap : IEntityTypeConfiguration<ProductPublisher>
    {
        public void Configure(EntityTypeBuilder<ProductPublisher> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.PublisherWagePercent).HasColumnType("decimal(18,2)");
            builder.HasOne(q => q.Product)
                .WithMany(q => q.ProductPublishers)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(q => q.Publisher)
                .WithMany(q => q.ProductPublishers)
                .HasForeignKey(q => q.PublisherId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
