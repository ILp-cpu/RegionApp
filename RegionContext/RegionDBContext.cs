using Microsoft.EntityFrameworkCore;
using System;

namespace RegionContext
{
    public class RegionDBContext:DbContext
    {
        public RegionDBContext(DbContextOptions<RegionDBContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

       // public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}

