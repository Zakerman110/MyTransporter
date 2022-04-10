using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Interfaces.Services
{
    public interface ICityService
    {
        Task<IEnumerable<CityResponse>> GetAsync();
        Task<CityResponse> GetByIdAsync(int id);
        Task AddAsync(CityRequest request);
        Task UpdateAsync(CityRequest request);
        Task DeleteAsync(int id);
    }
}
