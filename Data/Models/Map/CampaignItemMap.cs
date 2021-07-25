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
        }
    }
}
