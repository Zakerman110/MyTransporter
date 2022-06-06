using AutoMapper;
using FluentAssertions;
using Moq;
using Order.BLL.Configurations;
using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using Order.BLL.Interfaces.Services;
using Order.BLL.Services;
using Order.DAL.Entities;
using Order.DAL.Enums;
using Order.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Order.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IVehicleService> _vehicleService;
        private readonly Mock<IMapper> mockMapper;
        private readonly IMapper _mapper;

        public OrderServiceTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _vehicleService = new Mock<IVehicleService>();
            mockMapper = new Mock<IMapper>();

            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);

        }

        private List<DAL.Entities.Order> GetTestOrders()
        {
            var orders = new List<DAL.Entities.Order>
            {
                new DAL.Entities.Order { Id = 1, OrderDate = new DateTime(2022, 10, 12), OrderStatus = OrderStatus.COMPLETED, VehicleId = 1,
                    UserId = "bJKASdbhkAGS14kjASgkjas" },
                new DAL.Entities.Order { Id = 2, OrderDate = new DateTime(2022, 10, 13), OrderStatus = OrderStatus.COMPLETED, VehicleId = 2,
                    UserId = "jhasfkjASJKfhjshfkajsfh" },
                new DAL.Entities.Order { Id = 3, OrderDate = new DateTime(2022, 10, 15), OrderStatus = OrderStatus.PENDING, VehicleId = 1,
                    UserId = "lkeuqyhUAShiuasfoaHAsfq" },
                new DAL.Entities.Order { Id = 4, OrderDate = new DateTime(2022, 10, 16), OrderStatus = OrderStatus.PENDING, VehicleId = 2,
                    UserId = "JHasfoh1hkjhjhAOShkgfqm" }
            };

            return orders;
        }

        [Fact]
        public async Task GetOrders_ReturnsListOfOrders()
        {
            // Arrange
            _unitOfWork.Setup(x => x.OrdersRepository.Get()).ReturnsAsync(GetTestOrders());
            var service = new OrderService(_mapper, _unitOfWork.Object, _vehicleService.Object);

            // Act
            var result = await service.GetAsync();

            // Assert
            result.Count().Should().Be(4);
        }

        [Fact]
        public async Task GetOrders_ReturnsEmptyList()
        {
            // Arrange
            _unitOfWork.Setup(x => x.OrdersRepository.Get()).ReturnsAsync(new List<DAL.Entities.Order>());
            var service = new OrderService(_mapper, _unitOfWork.Object, _vehicleService.Object);

            // Act
            var result = await service.GetAsync();

            // Assert
            result.Count().Should().Be(0);
        }

        [Fact]
        public async Task GetCompleteOrders_ReturnsListOfOrders()
        {
            // Arrange
            _unitOfWork.Setup(x => x.OrdersRepository.GetComplete()).ReturnsAsync(GetTestOrders());
            var service = new OrderService(_mapper, _unitOfWork.Object, _vehicleService.Object);

            // Act
            var result = await service.GetCompleteAsync();

            // Assert
            result.Count().Should().Be(4);
        }

        [Fact]
        public async Task GetById_ReturnsSingleOrder()
        {
            // Arrange
            var orderId = 1;
            var searchOrder = GetTestOrders().FirstOrDefault(o => o.Id == orderId);
            _unitOfWork.Setup(x => x.OrdersRepository.FindById(orderId)).ReturnsAsync(searchOrder);
            var service = new OrderService(_mapper, _unitOfWork.Object, _vehicleService.Object);

            // Act
            var result = await service.GetByIdAsync(orderId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(searchOrder.Id);
        }

        [Fact]
        public async Task GetByIdDetail_ReturnsSingleOrder()
        {
            // Arrange
            var orderId = 1;
            var searchOrder = GetTestOrders().FirstOrDefault(o => o.Id == orderId);
            _unitOfWork.Setup(x => x.OrdersRepository.GetDetail(orderId)).ReturnsAsync(searchOrder);
            var service = new OrderService(_mapper, _unitOfWork.Object, _vehicleService.Object);

            // Act
            var result = await service.GetByIdDetailAsync(orderId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(searchOrder.Id);
        }

        [Fact]
        public async Task GetByVehicleId_ReturnsListOfOrders()
        {
            // Arrange
            var vehicleId = 1;
            _unitOfWork.Setup(x => x.OrdersRepository.GetByVehicleId(vehicleId))
                .ReturnsAsync(GetTestOrders().Where(o => o.VehicleId == vehicleId).ToList());
            var service = new OrderService(_mapper, _unitOfWork.Object, _vehicleService.Object);

            // Act
            var result = await service.GetByVehicleId(vehicleId);

            // Assert
            result.Count().Should().Be(2);
        }

        [Fact]
        public async Task AddOrder_ValidModel_ReturnsNewOrder()
        {
            // Arrange 
            _unitOfWork.Setup(x => x.OrdersRepository.Create(It.IsAny<DAL.Entities.Order>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            _unitOfWork.Setup(x => x.RouteRepository.Get())
                .ReturnsAsync(new List<Route>());
            _unitOfWork.Setup(x => x.JourneyRepository.Create(It.IsAny<Journey>()))
                .Returns(Task.CompletedTask);
            var service = new OrderService(_mapper, _unitOfWork.Object, _vehicleService.Object);
            var newOrder= new OrderRequest();

            // Act
            var result = await service.AddAsync(newOrder);

            // Assert
            var actionResult = Assert.IsType<OrderResponse>(result);
            _unitOfWork.Verify(x => x.OrdersRepository.Create(It.IsAny<DAL.Entities.Order>()), Times.Once);
        }

        [Fact]
        public async Task UpdateOrder_ValidModel_ReturnsTask()
        {
            // Arrange 
            _unitOfWork.Setup(x => x.OrdersRepository.Update(It.IsAny<DAL.Entities.Order>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            _unitOfWork.Setup(x => x.RouteRepository.Get())
                .ReturnsAsync(new List<Route>());
            _unitOfWork.Setup(x => x.JourneyRepository.FindById(It.IsAny<Int32>()))
                .ReturnsAsync(new Journey());
            _unitOfWork.Setup(x => x.JourneyRepository.Update(It.IsAny<Journey>()))
                .Returns(Task.CompletedTask);
            var service = new OrderService(_mapper, _unitOfWork.Object, _vehicleService.Object);
            var editOrder = new OrderEditRequest();

            // Act
            await service.UpdateAsync(editOrder);

            // Assert
            _unitOfWork.Verify(x => x.OrdersRepository.Update(It.IsAny<DAL.Entities.Order>()), Times.Once);
        }

        [Fact]
        public async Task Delete_IdValid_ReturnsTask()
        {
            // Arrange 
            int orderId = 1;
            _unitOfWork.Setup(x => x.OrdersRepository.Remove(orderId))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var service = new OrderService(_mapper, _unitOfWork.Object, _vehicleService.Object);

            // Act
            await service.DeleteAsync(orderId);

            //Assert 
            _unitOfWork.Verify(x => x.OrdersRepository.Remove(orderId), Times.Once);
        }
    }
}
