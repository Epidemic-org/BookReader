using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductFileMap : IEntityTypeConfiguration<ProductFile>
    {
        public void Configure(EntityTypeBuilder<ProductFile> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q=> q.Title).IsRequired(false).IsUnicode(true);
            builder.Property(q=> q.Description).IsRequired(false).IsUnicode(true);
            builder.Property(q=> q.Pic).IsRequired(false).IsUnicode(true);
            builder.Property(q => q.FileType).HasColumnType("tinyint");
            builder.Property(q=> q.FileFormat).IsRequired(false).IsUnicode(true);
            builder.Property(q=> q.Path).IsRequired(true).IsUnicode(true);
            builder.Property(q => q.FileSize).HasColumnType("int");
            builder.Property(q=> q.FileName).IsRequired(true).IsUnicode(true).HasMaxLength(500);
            builder.Property(q=> q.FileTime).HasColumnType("time(7)");
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");
            builder.Property(q => q.DisplayOrder).HasColumnType("int");

            builder.HasOne(q => q.Product)
                .WithMany(q => q.ProductFiles)
                .HasForeignKey(q => q.ProductId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(q => q.Parent)
                .WithMany(q => q.ProductFiles)
                .HasForeignKey(q => q.ParentId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
