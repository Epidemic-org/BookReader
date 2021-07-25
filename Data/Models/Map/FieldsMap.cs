using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class FieldsMap : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
        
            builder.HasKey(f => f.Id);
            //foreignkey adminid
            //foreignkey groupid
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
