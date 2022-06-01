using Microsoft.EntityFrameworkCore;
using Order.DAL.Entities;
using Order.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Entities.Order>, IOrderRepository
    {
        public OrderRepository(MyTransporterOrderContext context) : base(context)
        {
        }

        public async Task<Entities.Order> GetDetail(int id)
        {
            var order = await _dbSet.Include(order => order.Route)
                                     .ThenInclude(route => route.StartPoint)
                                     .Include(order => order.Route)
                                     .ThenInclude(route => route.EndPoint)
                                     .Include(order => order.Journey)
                                     .SingleOrDefaultAsync(order => order.Id == id);

            return order;
        }

        public async Task<IEnumerable<Entities.Order>> GetByVehicleId(int id)
        {
            return await _dbSet.Where(o => o.VehicleId == id).ToListAsync();             
        }

        public async Task<IEnumerable<Entities.Order>> GetCompleteByUserId(string id)
        {
            var order = await _dbSet.Include(order => order.Route)
                                     .ThenInclude(route => route.StartPoint)
                                     .Include(order => order.Route)
                                     .ThenInclude(route => route.EndPoint)
                                     .Include(order => order.Journey)
                                     .Where(order => order.UserId == id)
                                     .ToListAsync();

            return order;
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesFreeOnDate(DateTime date)
        {
            var vehicles = await _context.Vehicles
                                    .Where(c => !_context.Orders
                                        .Include(order => order.Journey)
                                        // діапазон +5, -5 годин від вказаної не будуть доступними
                                        .Where(order => order.Journey.StartDate.AddHours(-5) < date && order.Journey.StartDate.AddHours(5) > date)
                                        .Select(b => b.VehicleId)
                                        .Contains(c.ExternalId)
                                    ).ToListAsync();

            return vehicles;
        }
    }
}
