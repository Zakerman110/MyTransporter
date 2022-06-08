using Order.DAL;
using Order.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Tests.IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(MyTransporterOrderContext db)
        {
            db.Orders.AddRange(GetSeedingOrders());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(MyTransporterOrderContext db)
        {
            db.Orders.RemoveRange(db.Orders);
            InitializeDbForTests(db);
        }

        public static List<DAL.Entities.Order> GetSeedingOrders()
        {
            return new List<DAL.Entities.Order>()
            {
                new DAL.Entities.Order
                {
                    Id = 1,
                    OrderDate = new DateTime(2022, 03, 15, 18, 00, 00),
                    OrderStatus = OrderStatus.COMPLETED,
                    UserId = "3d1fc722-331d-4cdf-8fd3-515ae3c42088",
                    VehicleId = 1,
                    RouteId = 3,
                    JourneyId = 1
                },
                new DAL.Entities.Order
                {
                    Id = 2,
                    OrderDate = new DateTime(2022, 03, 16, 15, 00, 00),
                    OrderStatus = OrderStatus.COMPLETED,
                    UserId = "e1c33bea-9908-4419-a124-b55c604b5bc8",
                    VehicleId = 1,
                    RouteId = 5,
                    JourneyId = 2
                },
                new DAL.Entities.Order
                {
                    Id = 3,
                    OrderDate = new DateTime(2022, 03, 18, 12, 35, 00),
                    OrderStatus = OrderStatus.COMPLETED,
                    UserId = "3d1fc722-331d-4cdf-8fd3-515ae3c42088",
                    VehicleId = 2,
                    RouteId = 7,
                    JourneyId = 3
                }
            };
        }
    }
}
