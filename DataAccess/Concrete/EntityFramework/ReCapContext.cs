using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=ReCap;Trusted_Connection=True");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brandies { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
