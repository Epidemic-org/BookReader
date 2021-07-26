using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.ProductCategory)
            .WithMany(s => s.Products)
            .HasForeignKey(d => d.ProductCategoryId)
            .IsRequired(true).OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.Title).HasMaxLength(50).IsRequired(true).IsUnicode(true);

            builder.Property(d => d.Description).IsRequired(false).IsUnicode(true);
            builder.Property(d => d.Tags).IsRequired(false).IsUnicode(true);

            builder.HasOne(d => d.User)
            .WithMany(w => w.Products)
            .HasForeignKey(d => d.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Admin)
            .WithMany(w => w.Products)
            .HasForeignKey(d => d.AdminId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.IsConfirmed).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.ConfirmDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired(false);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired();
            builder.Property(d => d.EditionDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired(false);
            builder.Property(d => d.ProductType).IsRequired(true).HasColumnType("tinyint");


        }
    }
}
