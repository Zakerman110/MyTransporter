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
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(MyTransporterOrderContext context) : base(context)
        {
        }
        public async Task<Route> GetDetail(int id)
        {
            var route = await _dbSet.Include(route => route.StartPoint)
                                     .Include(route => route.EndPoint)
                                     .Include(route => route.Orders)
                                     .SingleOrDefaultAsync(route => route.Id == id);

            return route;
        }
    }
}
