using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class RoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.RoleType).HasColumnType("tinyint");
            builder.Property(q => q.Name).IsRequired(false).IsUnicode().HasMaxLength(256);
            builder.Property(q => q.NormalizedName).IsRequired(false).IsUnicode().HasMaxLength(256);
            builder.Property(q => q.ConcurrencyStamp).IsRequired(false).IsUnicode();
        }
    }
}
