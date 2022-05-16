using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Seeding;

namespace Order.DAL.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(region => region.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(region => region.Name)
                   .HasMaxLength(50);

            new RegionSeeder().Seed(builder);
        }
    }
}
