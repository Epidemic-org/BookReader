using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductRelationMap : IEntityTypeConfiguration<ProductRelation>
    {
        public void Configure(EntityTypeBuilder<ProductRelation> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.RelationType).HasColumnType("tinyint");
            builder.HasOne(q => q.Product)
                .WithMany(q => q.ProductRelations)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(q => q.RelatedProduct)
                .WithMany(q => q.ProductRelations)
                .HasForeignKey(q => q.RelatedProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
