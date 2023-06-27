using System;
using JLAHeadquarters.StorageApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace JLAHeadquarters.StorageApp.Data
{
    public class StorageAppDbContext: DbContext
    {
        public DbSet<Hero> Heroes => Set<Hero>();
        public DbSet<Villian> Villlians => Set<Villian>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}

