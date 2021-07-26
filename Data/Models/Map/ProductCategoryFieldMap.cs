using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductCategoryFieldMap : IEntityTypeConfiguration<ProductCategoryField>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryField> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(s => s.ProductCategory)
            .WithMany(g => g.ProductCategoryFields)
            .HasForeignKey(s => s.ProductCategoryId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Field)
            .WithMany(g => g.ProductCategoryFields)
            .HasForeignKey(s => s.FieldId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
