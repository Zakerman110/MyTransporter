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

namespace Order.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderResponse>> GetAsync()
        {
            var orders = await _unitOfWork.OrdersRepository.Get();
            return orders.Select(_mapper.Map<DAL.Entities.Order, OrderResponse>);
        }

        public Task<IEnumerable<OrderResponse>> GetDetailAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderResponse> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.OrdersRepository.FindById(id);
            return _mapper.Map<DAL.Entities.Order, OrderResponse>(order);
        }

        public async Task<OrderResponse> GetByIdDetailAsync(int id)
        {
            var order = await _unitOfWork.OrdersRepository.GetDetail(id);
            return _mapper.Map<DAL.Entities.Order, OrderResponse>(order);
        }

        public async Task<IEnumerable<OrderResponse>> GetByVehicleId(int id)
        {
            var orders = await _unitOfWork.OrdersRepository.GetByVehicleId(id);
            return orders.Select(_mapper.Map<DAL.Entities.Order, OrderResponse>);
        }

        public async Task<OrderResponse> AddAsync(OrderRequest request)
        {
            var order = _mapper.Map<OrderRequest, DAL.Entities.Order>(request);

            order.OrderDate = DateTime.Now;
            order.OrderStatus = DAL.Enums.OrderStatus.PENDING;

            var journey = _mapper.Map<JourneyRequest, Journey>(request.Journey);
            await _unitOfWork.JourneyRepository.Create(journey);

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
    }
}
