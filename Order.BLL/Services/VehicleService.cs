using Microsoft.EntityFrameworkCore;
using Order.BLL.Interfaces.Services;
using Order.DAL;
using Order.DAL.Entities;
using Order.DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly MyTransporterOrderContext _context;

        public VehicleService(MyTransporterOrderContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Vehicle request)
        {
            await _context.Vehicles.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Vehicles.Remove(entity);
        }

        public async Task<IEnumerable<Vehicle>> GetAsync()
        {
            var entities = await _context.Vehicles.AsNoTracking().ToListAsync();

            if (entities is null)
            {
                throw new NotFoundException($"{typeof(Vehicle).Name} not found.");
            }

            return entities;
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _context.Vehicles.SingleOrDefaultAsync(a => a.ExternalId == id) ?? throw new NotFoundException($"{typeof(Vehicle).Name} with id {id} not found.");
        }

        public async Task UpdateAsync(Vehicle request)
        {
            var entity = await GetByIdAsync(request.Id);
            _context.Entry(entity).State = EntityState.Detached;
            await Task.Run(() => _context.Vehicles.Update(request));
        }

        public async Task<bool> VehicleExternalExist(int externalId)
        {
            return await _context.Vehicles.AnyAsync(p => p.ExternalId == externalId);
        }
    }
}
