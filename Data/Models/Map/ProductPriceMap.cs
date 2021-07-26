using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductPriceMap : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.IsActive).HasColumnType("bit");
            builder.Property(q => q.StartDate).HasColumnType("datatime2(7)");
            builder.Property(q => q.EndDate).HasColumnType("datatime2(7)");
            builder.Property(q => q.CreationDate).HasColumnType("datatime2(7)");
            builder.Property(q => q.ProductPriceValue).HasColumnType("decimal(18,0)");
            builder.HasOne(q => q.Product)
                .WithMany(q => q.ProductPrices)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.Admin)
                .WithMany(q => q.ProductPrices)
                .HasForeignKey(q => q.AdminId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
