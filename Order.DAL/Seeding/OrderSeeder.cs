using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Interfaces;

namespace Order.DAL.Seeding
{
    public class OrderSeeder : ISeeder<Entities.Order>
    {
        List<Entities.Order> Orders = new()
        {
            new Entities.Order
            {
                Id = 1,
                OrderDate = new DateTime(2022, 03, 15, 18, 00, 00),
                OrderStatus = Enums.OrderStatus.COMPLETED,
                CustomerId = 1,
                VehicleId = 1,
                RouteId = 3,
                JourneyId = 1
            },
            new Entities.Order
            {
                Id = 2,
                OrderDate = new DateTime(2022, 03, 16, 15, 00, 00),
                OrderStatus = Enums.OrderStatus.COMPLETED,
                CustomerId = 2,
                VehicleId = 1,
                RouteId = 5,
                JourneyId = 2
            },
            new Entities.Order
            {
                Id = 3,
                OrderDate = new DateTime(2022, 03, 18, 12, 35, 00),
                OrderStatus = Enums.OrderStatus.COMPLETED,
                CustomerId = 3,
                VehicleId = 2,
                RouteId = 7,
                JourneyId = 3
            }
        };

        public void Seed(EntityTypeBuilder<Entities.Order> builder) => builder.HasData(Orders);
    }
}
