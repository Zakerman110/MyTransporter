using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.BLL.DTO.Request;
using Transport.BLL.DTO.Response;

namespace Transport.BLL.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleResponse>> GetAsync();
        Task<IEnumerable<VehicleModelResponse>> GetDetailAsync();
        Task<VehicleResponse> GetByIdAsync(int id);
        Task<VehicleModelResponse> GetByIdDetailAsync(int id);
        Task AddAsync(VehicleRequest request);
        Task UpdateAsync(VehicleRequest request);
        Task DeleteAsync(int id);
    }
}
