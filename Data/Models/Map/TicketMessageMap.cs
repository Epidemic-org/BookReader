using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class TicketMessageMap : IEntityTypeConfiguration<TicketMessage>
    {
        public void Configure(EntityTypeBuilder<TicketMessage> builder) {
            builder.Property(t => t.Id);
            builder.Property(d => d.Text).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");
            builder.Property(d => d.SeenDate).HasColumnType("datetime2(7)");

            builder.HasOne(t => t.Admin)
            .WithMany(u => u.AdminTicketMessages)
            .HasForeignKey(t => t.AdminId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;

            builder.HasOne(t => t.User)
            .WithMany(u => u.UserTicketMessages)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;



            builder.HasOne(t => t.Ticket)
            .WithMany(u => u.TicketMessages)
            .HasForeignKey(t => t.TicketId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;

        }
    }
}
