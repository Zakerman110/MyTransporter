using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Order.DAL.Configurations;
using Order.DAL.Entities;

namespace Order.DAL
{
    public partial class MyTransporterOrderContext : DbContext
    {
        public MyTransporterOrderContext(DbContextOptions<MyTransporterOrderContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Entities.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
        }
    }
}
