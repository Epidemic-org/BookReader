﻿using Microsoft.EntityFrameworkCore;
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
            builder.Property(f => f.Title).HasMaxLength(50).IsRequired(true).IsUnicode(true);

            builder.Property(d => d.Description).IsRequired(false).IsUnicode(false);

            builder.HasOne(d => d.Category)
                .WithMany(w => w.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction)
                ;
            
        }
    }
}