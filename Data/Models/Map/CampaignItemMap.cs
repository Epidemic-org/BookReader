using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class CampaignItemMap : IEntityTypeConfiguration<CampaignItem>
    {
        public void Configure(EntityTypeBuilder<CampaignItem> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(s =>s.Campaingn)
            .WithMany(g => g.CampaignItems)
            .HasForeignKey(s => s.CampaingnId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.ProductCategory)
            .WithMany(g => g.CampaignItems)
            .HasForeignKey(s => s.ProductCategoryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Product)
            .WithMany(g => g.CampaignItems)
            .HasForeignKey(s => s.ProductId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
