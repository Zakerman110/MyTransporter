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
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CountryResponse>> GetAsync()
        {
            var countries = await _unitOfWork.CountryRepository.Get();
            return countries.Select(_mapper.Map<Country, CountryResponse>);
        }

        public Task<IEnumerable<CountryRegionsResponse>> GetDetailAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CountryResponse> GetByIdAsync(int id)
        {
            var country = await _unitOfWork.CountryRepository.FindById(id);
            return _mapper.Map<Country, CountryResponse>(country);
        }

        public Task<CountryRegionsResponse> GetByIdDetailAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<CountryResponse> AddAsync(CountryRequest request)
        {
            var country = _mapper.Map<CountryRequest, Country>(request);
            await _unitOfWork.CountryRepository.Create(country);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<Country, CountryResponse>(country);
        }

        public async Task UpdateAsync(CountryRequest request)
        {
            var country = _mapper.Map<CountryRequest, Country>(request);
            await _unitOfWork.CountryRepository.Update(country);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CountryRepository.Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
