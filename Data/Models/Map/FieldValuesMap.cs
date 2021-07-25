using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class FieldValuesMap : IEntityTypeConfiguration<FieldValue>
    {
        public void Configure(EntityTypeBuilder<FieldValue> builder)
        {
            builder.HasKey(f => f.Id);
            //foreignkey fieldid
            builder.Property(d => d.Value).HasMaxLength(100).IsUnicode(true).IsRequired(true);

        }
    }
}
