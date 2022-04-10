using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Interfaces.Services
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionResponse>> GetAsync();
        Task<IEnumerable<RegionCitiesResponse>> GetDetailAsync();
        Task<RegionResponse> GetByIdAsync(int id);
        Task<RegionCitiesResponse> GetByIdDetailAsync(int id);
        Task AddAsync(RegionRequest request);
        Task UpdateAsync(RegionRequest request);
        Task DeleteAsync(int id);
    }
}
