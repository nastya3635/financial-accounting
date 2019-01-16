using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace test2.Models
{
    public class CostsContext : DbContext
    {
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public CostsContext(DbContextOptions<CostsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
