using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductTranslatorMap : IEntityTypeConfiguration<ProductTranslator>
    {
        public void Configure(EntityTypeBuilder<ProductTranslator> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.TranslatorWagePercent).HasColumnType("decimal(18,2)");
            builder.HasOne(q => q.Product)
                .WithMany(q => q.ProductTranslators)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(q => q.Translator)
                .WithMany(q => q.ProductTranslators)
                .HasForeignKey(q => q.TranslatorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
