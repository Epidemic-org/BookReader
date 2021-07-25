using BookReader.Data.Models;
using BookReader.Data.Models.Map;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReader.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Product>(new ProductMap());
            builder.ApplyConfiguration<Category>(new CategoryMap());


            base.OnModelCreating(builder);
        }
    }
}
