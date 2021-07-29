using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Data.Models.Map
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(e => e.Id);

            builder.Property(e => e.BirthDate).HasColumnType("date");

            builder.Property(e => e.FirstName).HasMaxLength(75);

            builder.Property(e => e.IsAcceptRules)
                .IsRequired();

            builder.Property(e => e.LastName).HasMaxLength(75);

            builder.Property(e => e.NationalCode).HasMaxLength(11);

            builder.Property(e => e.Phone).HasMaxLength(11);

            builder.HasOne<AppUser>(d => d.User)
                .WithOne(p => p.Person)
                .HasForeignKey<Person>(d=> d.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(d => new { d.UserId}).IsUnique();


            builder.HasData(new Person
            {
                Id = 1,
                UserId = 1,
                FirstName = "Abbas",
                LastName = "Kashi",
                BirthDate = new DateTime(1990, 12, 20),
                CreationDate = DateTime.Now,
                GenderType = 1,
                IsAcceptRules = 1,
                NationalCode = "1250001112",
            });
        }
    }
}
