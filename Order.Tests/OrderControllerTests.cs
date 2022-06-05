using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Order.BLL.Configurations;
using Order.BLL.DTO.Responses;
using Order.BLL.Interfaces.Services;
using Order.DAL.Entities;
using Order.DAL.Enums;
using Order.DAL.Exceptions;
using Order.WebAPI.Controllers;
using Xunit;

namespace Order.Tests
{
    public class OrderControllerTests
    {

        /*private readonly IMapper _mapper;

        public OrderControllerTests()
        {
            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }*/

        private List<OrderResponse> GetTestOrders()
        {
            var orders = new List<OrderResponse>
            {
                new OrderResponse { Id = 1, PlaceDate = new DateTime(2022, 10, 12), Status = OrderStatus.COMPLETED,
                    UserId = "bJKASdbhkAGS14kjASgkjas" },
                new OrderResponse { Id = 2, PlaceDate = new DateTime(2022, 10, 13), Status = OrderStatus.COMPLETED,
                    UserId = "jhasfkjASJKfhjshfkajsfh" },
                new OrderResponse { Id = 3, PlaceDate = new DateTime(2022, 10, 15), Status = OrderStatus.PENDING,
                    UserId = "lkeuqyhUAShiuasfoaHAsfq" },
                new OrderResponse { Id = 4, PlaceDate = new DateTime(2022, 10, 16), Status = OrderStatus.PENDING,
                    UserId = "JHasfoh1hkjhjhAOShkgfqm" }
            };

            return orders;
        }

        [Fact]
        public async Task GetOrderById_ExistingId_ReturnsActionResultWithCustomer()
        {
            // Arrange
            int testOrderId = 1;
            var mockRepo = new Mock<IOrderService>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testOrderId))
                .ReturnsAsync(GetTestOrders().FirstOrDefault(c => c.Id == testOrderId));
            var controller = new OrderController(mockRepo.Object);

            // Act
            var actionResult = await controller.GetOrderById(testOrderId);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var entity = Assert.IsType<OrderResponse>(result.Value);
            Assert.Equal(testOrderId, entity.Id);
            Assert.Equal(OrderStatus.COMPLETED, entity.Status);
        }

        [Fact]
        public async Task GetOrderById_NotExistingId_ThrowsNotFoundException()
        {
            // Arrange
            int testOrderId = 0;
            var mockRepo = new Mock<IOrderService>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testOrderId))
                .ThrowsAsync(new NotFoundException($"Order with id {testOrderId} not found."));
            var controller = new OrderController(mockRepo.Object);

            // Act
            Task act() => controller.GetOrderById(testOrderId);

            // Assert
            NotFoundException exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("Order with id 0 not found.", exception.Message);

             /*// Assert
             NotFoundException exception = await Assert.ThrowsAsync<NotFoundException>(async () => await controller.GetOrderById(testOrderId));
            Assert.Equal("Order with id 0 not found.", exception.Message);*/
        }
    }
}
