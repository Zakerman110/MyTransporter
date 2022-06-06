using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Order.DAL;
using Order.DAL.Interfaces.Repositories;
using Order.DAL.Repositories;
using Order.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Order.Tests
{
    public class OrderRepositoryTests
    {
        DbContextOptions<MyTransporterOrderContext> options;

        public OrderRepositoryTests()
        {

            options = new DbContextOptionsBuilder<MyTransporterOrderContext>()
            .UseInMemoryDatabase(databaseName: "OrderListDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new MyTransporterOrderContext(options))
            {
                if(!context.Orders.Any())
                {
                    context.Orders.Add(new DAL.Entities.Order
                    {
                        Id = 1,
                        UserId = "userdId1",
                        VehicleId = 1,
                        OrderDate = new DateTime(2022, 11, 06),
                        OrderStatus = DAL.Enums.OrderStatus.COMPLETED,
                        JourneyId = 1,
                        RouteId = 1
                    });
                    context.Orders.Add(new DAL.Entities.Order
                    {
                        Id = 2,
                        UserId = "userdId2",
                        VehicleId = 2,
                        OrderDate = new DateTime(2022, 11, 07),
                        OrderStatus = DAL.Enums.OrderStatus.PENDING,
                        JourneyId = 2,
                        RouteId = 2
                    });
                    context.Orders.Add(new DAL.Entities.Order
                    {
                        Id = 3,
                        UserId = "userdId3",
                        VehicleId = 1,
                        OrderDate = new DateTime(2022, 11, 08),
                        OrderStatus = DAL.Enums.OrderStatus.PENDING,
                        JourneyId = 3,
                        RouteId = 1
                    });
                    context.SaveChanges();
                }
            }
        }

        [Fact]
        public async Task Create_AddNewOrder()
        {
            var mockSet = new Mock<DbSet<DAL.Entities.Order>>();

            var mockContext = new Mock<MyTransporterOrderContext>();
            mockContext.Setup(m => m.Orders).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<DAL.Entities.Order>()).Returns(mockSet.Object);

            var repository = new OrderRepository(mockContext.Object);
            var order = new DAL.Entities.Order();

            await repository.Create(order);

            mockSet.Verify(m => m.AddAsync(It.IsAny<DAL.Entities.Order>(), It.IsAny<System.Threading.CancellationToken>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());

            /*using (var context = new MyTransporterOrderContext(options))
            {
                // Arrange
                var repository = new OrderRepository(context);
                var order = new DAL.Entities.Order();

                // Act
                await repository.Create(order);

                // Assert
                Assert.Equal(3, orders.Count());
            }*/
        }

        [Fact]
        public async Task Get_ReturnsListOfOrders()
        {

            using (var context = new MyTransporterOrderContext(options))
            {
                // Arrange
                var repository = new OrderRepository(context);

                // Act
                var orders = await repository.Get();

                // Assert
                Assert.Equal(3, orders.Count());
            }
        }
    }
}
