using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class GroupFieldsMap : IEntityTypeConfiguration<GroupField>
    {
        public void Configure(EntityTypeBuilder<GroupField> builder)
        {

            builder.HasKey(f => f.Id);
            builder.Property(d => d.GroupName).IsRequired(true).IsUnicode(true).HasMaxLength(50);
            //foreignkey adminid
            builder.Property(d => d.CreationDate).IsRequired(true).HasMaxLength(7).HasColumnType("datetime2");

        }
    }
}
