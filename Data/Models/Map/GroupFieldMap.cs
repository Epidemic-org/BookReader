using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class GroupFieldMap : IEntityTypeConfiguration<GroupField>
    {
        public void Configure(EntityTypeBuilder<GroupField> builder)
        {

            builder.HasKey(f => f.Id);
            builder.Property(d => d.GroupName).IsRequired(true).IsUnicode(true).HasMaxLength(50);

            builder.HasOne(s => s.Admin)
           .WithMany(g => g.GroupFields)
           .HasForeignKey(s => s.AdminId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.CreationDate).IsRequired(true).HasMaxLength(7).HasColumnType("datetime2");

        }
    }
}
