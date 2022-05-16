using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Seeding;

namespace Order.DAL.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(city => city.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(city => city.Name)
                   .HasMaxLength(50);

            new CitySeeder().Seed(builder);
        }
    }
}
