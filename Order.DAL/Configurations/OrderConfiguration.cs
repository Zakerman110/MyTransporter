using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Seeding;

namespace Order.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Entities.Order> builder)
        {
            builder.Property(order => order.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(order => order.OrderDate)
                   .HasColumnType("datetime");

            new OrderSeeder().Seed(builder);
        }
    }
}
