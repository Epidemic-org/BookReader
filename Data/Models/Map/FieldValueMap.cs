using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class FieldValueMap : IEntityTypeConfiguration<FieldValue>
    {
        public void Configure(EntityTypeBuilder<FieldValue> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(s => s.Field)
           .WithMany(g => g.FieldValues)
           .HasForeignKey(s => s.FieldId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.Value).HasMaxLength(100).IsUnicode(true).IsRequired(true);

        }
    }
}
