using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Seeding;

namespace Order.DAL.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(country => country.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(country => country.Name)
                   .HasMaxLength(50);

            new CountrySeeder().Seed(builder);
        }
    }
}
