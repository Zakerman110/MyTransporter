using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using Order.DAL.Seeding;

namespace Order.DAL.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.Property(r => r.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.HasOne(r => r.StartPoint)
                   .WithMany(c => c.StartPoints)
                   .HasForeignKey(r => r.StartPointId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.EndPoint)
                   .WithMany(c => c.EndPoints)
                   .HasForeignKey(r => r.EndPointId)
                   .OnDelete(DeleteBehavior.NoAction);

            new RouteSeeder().Seed(builder);
        }
    }
}
