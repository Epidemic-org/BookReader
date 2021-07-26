using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(s => s.Parent)
           .WithMany(g => g.ProductCategories)
           .HasForeignKey(s => s.ParentId)
           .IsRequired(false)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.Name).IsRequired(true).IsUnicode(true).HasMaxLength(100);
            builder.Property(d => d.Description).IsRequired(false).IsUnicode(true);
            builder.Property(d => d.DisplayOrder).IsRequired(true);
            builder.Property(d => d.Pic).IsRequired(false).IsUnicode(true);
            builder.Property(d => d.Icon).IsRequired(false).IsUnicode(true);
            builder.Property(d => d.IsActive).IsRequired(true);
            builder.Property(d => d.IsActive).IsRequired(true);

            builder.HasOne(s => s.Admin)
           .WithMany(g => g.ProductCategories)
           .HasForeignKey(s => s.AdminId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.CreationDate).IsRequired(true).HasColumnType("datetime2").HasMaxLength(7);
            builder.Property(d => d.ProductType).IsRequired(true).HasColumnType("tinyint");




        }
    }
}
