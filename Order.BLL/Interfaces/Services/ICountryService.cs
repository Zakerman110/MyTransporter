using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Interfaces.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryResponse>> GetAsync();
        Task<IEnumerable<CountryRegionsResponse>> GetDetailAsync();
        Task<CountryResponse> GetByIdAsync(int id);
        Task<CountryRegionsResponse> GetByIdDetailAsync(int id);
        Task<CountryResponse> AddAsync(CountryRequest request);
        Task UpdateAsync(CountryRequest request);
        Task DeleteAsync(int id);
    }
}
