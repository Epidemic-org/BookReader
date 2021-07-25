using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class FormActionsMap : IEntityTypeConfiguration<FormAction>
    {
        public void Configure(EntityTypeBuilder<FormAction> builder)
        {
            builder.HasKey(f => f.Id);
            //foreignkey parentid
            builder.Property(d => d.FormName).IsRequired(true).IsUnicode(true).HasMaxLength(50);
            builder.Property(d => d.Area).IsRequired(false).IsUnicode(false).HasMaxLength(50);

        }
    }
}
