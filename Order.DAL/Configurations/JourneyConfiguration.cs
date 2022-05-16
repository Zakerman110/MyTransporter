using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Seeding;

namespace Order.DAL.Configurations
{
    public class JourneyConfiguration : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.Property(journey => journey.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(journey => journey.StartDate)
                   .HasColumnType("datetime");

            builder.Property(journey => journey.EndDate)
                   .HasColumnType("datetime");

            new JourneySeeder().Seed(builder);
        }
    }
}
