using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductDownloadMap : IEntityTypeConfiguration<ProductDownload>
    {
        public void Configure(EntityTypeBuilder<ProductDownload> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasOne(q => q.Product)
                .WithMany(q => q.ProductDownloads)
                .HasForeignKey(q => q.ProductId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(q => q.User)
                .WithMany(q => q.ProductDownloads)
                .HasForeignKey(q => q.UserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.CreationDate).HasColumnType("datetime").IsRequired(true);

        }
    }
}
