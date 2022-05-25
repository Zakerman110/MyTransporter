using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAsync();
        Task<Vehicle> GetByIdAsync(int id);
        Task AddAsync(Vehicle request);
        Task<bool> VehicleExternalExist(int externalId);
        Task UpdateAsync(Vehicle request);
        Task DeleteAsync(int id);
    }
}
