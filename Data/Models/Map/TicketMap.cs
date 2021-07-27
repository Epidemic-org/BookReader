using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder) {
            builder.Property(t => t.Id);
            builder.Property(d => d.Title).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");
        }
    }
}
