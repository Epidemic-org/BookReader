using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductFieldValueMap : IEntityTypeConfiguration<ProductFieldValue>
    {
        public void Configure(EntityTypeBuilder<ProductFieldValue> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.Field)
                .WithMany(p => p.ProductFieldValues)
                .HasForeignKey(d => d.FieldId).IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.FieldValue)
                .WithMany(p => p.ProductFieldValues)
                .HasForeignKey(d => d.FieldValueId).IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductFieldValues)
                .HasForeignKey(d => d.ProductId).IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
