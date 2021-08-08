using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductRateMap : IEntityTypeConfiguration<ProductRate>
    {
        public void Configure(EntityTypeBuilder<ProductRate> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.RateValue).HasColumnType("real");

            builder.HasOne(q => q.Product)
                .WithMany(q => q.ProductRates)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(q => q.User)
                .WithMany(q => q.ProductRates)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
