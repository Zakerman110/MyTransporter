using AutoMapper;
using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using Order.BLL.Interfaces.Services;
using Order.DAL.Entities;
using Order.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Services
{
    public class RouteService : IRouteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RouteService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RouteResponse>> GetAsync()
        {
            var routes = await _unitOfWork.RouteRepository.Get();
            return routes.Select(_mapper.Map<Route, RouteResponse>);
        }

        public Task<IEnumerable<RouteResponse>> GetDetailAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RouteResponse> GetByIdAsync(int id)
        {
            var route = await _unitOfWork.RouteRepository.FindById(id);
            return _mapper.Map<Route, RouteResponse>(route);
        }

        public async Task<RouteResponse> GetByIdDetailAsync(int id)
        {
            var route = await _unitOfWork.RouteRepository.GetDetail(id);
            return _mapper.Map<Route, RouteResponse>(route);
        }


        public async Task AddAsync(RouteRequest request)
        {
            var route = _mapper.Map<RouteRequest, Route>(request);
            await _unitOfWork.RouteRepository.Create(route);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(RouteRequest request)
        {
            var route = _mapper.Map<RouteRequest, Route>(request);
            await _unitOfWork.RouteRepository.Update(route);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.RouteRepository.Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
