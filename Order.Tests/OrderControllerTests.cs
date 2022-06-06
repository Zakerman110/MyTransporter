using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Order.BLL.Configurations;
using Order.BLL.DTO.Requests;
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
            entity.Id.Should().Be(testOrderId);
            entity.Status.Should().Be(OrderStatus.COMPLETED);
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
            exception.Message.Should().Be("Order with id 0 not found.");
        }

        [Fact]
        public async Task Get_ReturnsListOfOrders()
        {
            // Arrange
            var mockRepo = new Mock<IOrderService>();
            mockRepo.Setup(repo => repo.GetAsync())
                .ReturnsAsync(GetTestOrders());
            var controller = new OrderController(mockRepo.Object);

            // Act
            var actionResult = await controller.Get();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var entity = Assert.IsType<List<OrderResponse>>(result.Value);
            entity.Count().Should().Be(4);
        }

        [Fact]
        public async Task Get_ThrowsNotFound()
        {
            // Arrange
            var mockRepo = new Mock<IOrderService>();
            mockRepo.Setup(repo => repo.GetAsync())
                .Throws(new NotFoundException("Order not found."));
            var controller = new OrderController(mockRepo.Object);

            // Act
            var actionResult = await controller.Get();

            // Assert
            actionResult.Result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public async Task Post_ReturnsCreatedAtRoute()
        {
            //Arrange
            var newOrder = new OrderRequest();
            var newOrderId = 4; // Last in list
            var mockRepo = new Mock<IOrderService>();
            mockRepo.Setup(repo => repo.AddAsync(newOrder))
                .ReturnsAsync(new OrderResponse() { Id = newOrderId });
            var controller = new OrderController(mockRepo.Object);

            //Act
            ActionResult<OrderResponse> actionResult = await controller.Post(newOrder);
            CreatedAtRouteResult result = actionResult.Result as CreatedAtRouteResult;
            var actual = result.Value as OrderResponse;

            //Assert
            actual.Id.Should().Be(newOrderId);
        }

        [Fact]
        public async Task Put_ReturnsOk()
        {
            //Arrange
            var editOrder = new OrderEditRequest();
            var mockRepo = new Mock<IOrderService>();
            var controller = new OrderController(mockRepo.Object);

            //Act
            var actionResult = await controller.Put(editOrder);

            //Assert
            actionResult.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Delete_ReturnsOk()
        {
            //Arrange
            var orderId = 1;
            var mockRepo = new Mock<IOrderService>();
            var controller = new OrderController(mockRepo.Object);

            //Act
            var actionResult = await controller.Delete(orderId);

            //Assert
            actionResult.Should().BeOfType<OkResult>();
        }
    }
}
