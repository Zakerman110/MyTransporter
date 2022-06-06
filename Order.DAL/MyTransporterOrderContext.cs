using Microsoft.EntityFrameworkCore;
using Order.DAL.Configurations;
using Order.DAL.Entities;

namespace Order.DAL
{
    public partial class MyTransporterOrderContext : DbContext
    {
        public MyTransporterOrderContext(DbContextOptions<MyTransporterOrderContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public MyTransporterOrderContext()
        {

        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Journey> Journeys { get; set; }
        public virtual DbSet<Entities.Order> Orders { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
            modelBuilder.ApplyConfiguration(new JourneyConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());

        }
    }
}
