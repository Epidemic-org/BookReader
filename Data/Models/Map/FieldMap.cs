using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class FieldMap : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {

            builder.HasKey(f => f.Id);

            builder.HasOne(s => s.Admin)
           .WithMany(g => g.Fields)
           .HasForeignKey(s => s.AdminId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.GroupField)
            .WithMany(g => g.Fields)
            .HasForeignKey(s => s.GroupId)
           .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
            
            builder.Property(d => d.FieldName).IsRequired(true).HasMaxLength(75).IsUnicode(true);
            builder.Property(d => d.FieldIcon).IsRequired(false).IsUnicode(true);
            builder.Property(d => d.FieldType).IsRequired(true).HasColumnType("tinyint");
            builder.Property(d => d.IsRequired).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.IsSearchable).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.IsActive).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.IsGlobal).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.CreationDate).IsRequired(true).HasColumnType("datetime2").HasMaxLength(7);

        }
    }
}
