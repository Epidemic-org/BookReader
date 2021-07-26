using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductVisitMap : IEntityTypeConfiguration<ProductVisit>
    {
        public void Configure(EntityTypeBuilder<ProductVisit> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.CreationDate).HasColumnType("datatime");
            builder.HasOne(q => q.Product)
                .WithMany(q => q.ProductVisits)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(q => q.User)
                .WithMany(q => q.ProductVisits)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
