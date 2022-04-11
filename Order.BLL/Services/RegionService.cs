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
    public class RegionService : IRegionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RegionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RegionResponse>> GetAsync()
        {
            var regions = await _unitOfWork.RegionRepository.Get();
            return regions.Select(_mapper.Map<Region, RegionResponse>);
        }

        public Task<IEnumerable<RegionCitiesResponse>> GetDetailAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RegionResponse> GetByIdAsync(int id)
        {
            var region = await _unitOfWork.RegionRepository.FindById(id);
            return _mapper.Map<Region, RegionResponse>(region);
        }

        public async Task<RegionCitiesResponse> GetByIdDetailAsync(int id)
        {
            var region = await _unitOfWork.RegionRepository.GetDetail(id);
            return _mapper.Map<Region, RegionCitiesResponse>(region);
        }


        public async Task AddAsync(RegionRequest request)
        {
            var region = _mapper.Map<RegionRequest, Region>(request);
            await _unitOfWork.RegionRepository.Create(region);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(RegionRequest request)
        {
            var region = _mapper.Map<RegionRequest, Region>(request);
            await _unitOfWork.RegionRepository.Update(region);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.RegionRepository.Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
