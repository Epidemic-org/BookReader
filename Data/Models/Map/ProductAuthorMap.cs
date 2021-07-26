using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ProductAuthorMap : IEntityTypeConfiguration<ProductAuthor>
    {
        public void Configure(EntityTypeBuilder<ProductAuthor> builder)
        {

            builder.HasKey(f => f.Id);

            builder.HasOne(s => s.Product)
            .WithMany(g => g.ProductAuthors)
            .HasForeignKey(s => s.ProductId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(s => s.People)
            .WithMany(g => g.ProductAuthors)
            .HasForeignKey(s => s.AuthorId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.ProductAuthorWagePercent).IsRequired(true).HasColumnType("decimal").HasPrecision(18, 2); ;
        }

    }
}
