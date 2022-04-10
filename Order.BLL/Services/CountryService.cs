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

        public Task<CountryResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CountryRegionsResponse> GetByIdDetailAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task AddAsync(CountryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CountryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
