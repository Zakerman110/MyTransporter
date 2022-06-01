using AutoMapper;
using Order.BLL.DTO.Responses;
using Order.BLL.Interfaces.Services;
using Order.DAL.Interfaces;
using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.BLL.DTO.Requests;
using Order.DAL.Exceptions;

namespace Order.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVehicleService _vehicleService;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, IVehicleService vehicleService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _vehicleService = vehicleService;
        }

        public async Task<IEnumerable<OrderResponse>> GetAsync()
        {
            var orders = await _unitOfWork.OrdersRepository.Get();
            return orders.Select(_mapper.Map<DAL.Entities.Order, OrderResponse>);
        }

        public async Task<IEnumerable<OrderResponse>> GetCompleteAsync()
        {
            var orders = await _unitOfWork.OrdersRepository.GetComplete();

            return orders.Select(_mapper.Map<DAL.Entities.Order, OrderResponse>);
        }

        public async Task<OrderResponse> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.OrdersRepository.FindById(id);
            return _mapper.Map<DAL.Entities.Order, OrderResponse>(order);
        }

        public async Task<OrderResponse> GetByIdDetailAsync(int id)
        {
            var order = await _unitOfWork.OrdersRepository.GetDetail(id);

            var response = _mapper.Map<DAL.Entities.Order, OrderResponse>(order);
            try
            {
                response.Vehicle = await _vehicleService.GetByIdAsync(order.VehicleId);
            }
            catch (NotFoundException ex)
            {
                response.Vehicle = null;
            }

            return response;
        }

        public async Task<IEnumerable<OrderResponse>> GetByVehicleId(int id)
        {
            var orders = await _unitOfWork.OrdersRepository.GetByVehicleId(id);
            return orders.Select(_mapper.Map<DAL.Entities.Order, OrderResponse>);
        }

        public async Task<OrderResponse> AddAsync(OrderRequest request)
        {
            // Creating Route
            var route = _unitOfWork.RouteRepository.Get().Result.Where(route => 
                route.EndPointId == request.EndPointId && route.StartPointId == request.StartPointId).FirstOrDefault();

            if(route == null)
            {
                route = new Route() { StartPointId = request.StartPointId, EndPointId = request.EndPointId };
                _unitOfWork.RouteRepository.Create(route);
                await _unitOfWork.SaveChangesAsync();
            }

            // Creatin Journey
            var journey = new Journey() { StartDate = request.StartDate };
            _unitOfWork.JourneyRepository.Create(journey);
            await _unitOfWork.SaveChangesAsync();

            // Creating order
            var order = _mapper.Map<OrderRequest, DAL.Entities.Order>(request);

            order.OrderDate = DateTime.Now;
            order.OrderStatus = DAL.Enums.OrderStatus.PENDING;
            order.RouteId = route.Id;
            order.JourneyId = journey.Id;

            await _unitOfWork.OrdersRepository.Create(order);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DAL.Entities.Order, OrderResponse>(order);
        }

        public async Task UpdateAsync(OrderRequest request)
        {
            var order = _mapper.Map<OrderRequest, DAL.Entities.Order>(request);
            await _unitOfWork.OrdersRepository.Update(order);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.OrdersRepository.Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderResponse>> GetCompleteByUserId(string id)
        {
            var orders = await _unitOfWork.OrdersRepository.GetCompleteByUserId(id);
            return orders.Select(_mapper.Map<DAL.Entities.Order, OrderResponse>);
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesFreeOnDate(DateTime date)
        {
            var vehicles = await _unitOfWork.OrdersRepository.GetVehiclesFreeOnDate(date);
            return vehicles;
        }
    }
}
