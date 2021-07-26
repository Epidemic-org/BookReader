using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductPlayMap : IEntityTypeConfiguration<ProductPlay>
    {
        public void Configure(EntityTypeBuilder<ProductPlay> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.CreationDate).HasColumnType("datetime");
            builder.HasOne(q => q.Product)
                .WithMany(q => q.ProductPlays)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(q => q.User)
                .WithMany(q => q.ProductPlays)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
