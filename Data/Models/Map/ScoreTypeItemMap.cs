using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ScoreTypeItemMap : IEntityTypeConfiguration<ScoreTypeItem>
    {
        public void Configure(EntityTypeBuilder<ScoreTypeItem> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasOne(q => q.Product)
                .WithMany(q => q.ScoreTypeItems)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.ProductCategory)
                .WithMany(q => q.ScoreTypeItems)
                .HasForeignKey(q => q.ProductCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.ScoreType)
                .WithMany(q => q.ScoreTypeItems)
                .HasForeignKey(q => q.ScoreId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
