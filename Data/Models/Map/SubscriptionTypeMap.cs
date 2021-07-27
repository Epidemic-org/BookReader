using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class SubscriptionTypeMap : IEntityTypeConfiguration<SubscriptionType>
    {
        public void Configure(EntityTypeBuilder<SubscriptionType> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.DayCount).HasColumnType("int");
            builder.Property(q => q.Title).IsUnicode();
            builder.Property(q => q.Description).IsRequired(false).IsUnicode();
            builder.Property(q => q.CreationDate).HasColumnType("datetime2(7)");
            builder.Property(q => q.PriceAmount).HasColumnType("decimal(18,0)");
            builder.Property(q => q.IsActive).HasColumnType("bit");
            builder.Property(q => q.Icon).IsRequired(false).IsUnicode();
            builder.Property(q => q.Pic).IsRequired(false).IsUnicode();
            builder.HasOne(q => q.Admin)
                .WithMany(q => q.SubscriptionTypes)
                .HasForeignKey(q => q.AdminId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
