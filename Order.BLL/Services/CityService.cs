using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using Order.BLL.Interfaces.Services;
using Order.DAL.Entities;
using Order.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Order.BLL.Services
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache;

        public CityService(IMapper mapper, IUnitOfWork unitOfWork, IDistributedCache distributedCache)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
        }

        public async Task<IEnumerable<CityResponse>> GetAsync()
        {
            var cacheKey = "cityList";
            string serializedCityList;
            IEnumerable<City> cities = null;
            var redisCities = await _distributedCache.GetAsync(cacheKey);
            if(redisCities != null)
            {
                serializedCityList = Encoding.UTF8.GetString(redisCities);
                cities = JsonSerializer.Deserialize<List<City>>(serializedCityList);
            }
            else
            {
                cities = await _unitOfWork.CityRepository.Get();
                serializedCityList = JsonSerializer.Serialize(cities);
                redisCities = Encoding.UTF8.GetBytes(serializedCityList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisCities, options);
            }

            return cities.Select(_mapper.Map<City, CityResponse>);
        }

        public Task<IEnumerable<CityResponse>> GetDetailAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CityResponse> GetByIdAsync(int id)
        {
            var city = await _unitOfWork.CityRepository.FindById(id);
            return _mapper.Map<City, CityResponse>(city);
        }

        public async Task<CityResponse> GetByIdDetailAsync(int id)
        {
            var city = await _unitOfWork.CityRepository.GetDetail(id);
            return _mapper.Map<City, CityResponse>(city);
        }


        public async Task<CityResponse> AddAsync(CityRequest request)
        {
            var city = _mapper.Map<CityRequest, City>(request);
            await _unitOfWork.CityRepository.Create(city);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<City, CityResponse>(city);
        }

        public async Task UpdateAsync(CityRequest request)
        {
            var city = _mapper.Map<CityRequest, City>(request);
            await _unitOfWork.CityRepository.Update(city);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CityRepository.Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
