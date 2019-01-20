using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace test3
{
    public class CostsContext : DbContext
    {
        public CostsContext(DbContextOptions<CostsContext> options)
            : base(options)
        {
             Database.EnsureCreated();
        }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cost>();
            modelBuilder.Entity<Category>();
        }

    }
}
