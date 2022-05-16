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
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(MyTransporterOrderContext context) : base(context)
        {
        }
        public async Task<City> GetDetail(int id)
        {
            var city = await _dbSet.Include(city => city.Region)
                                     .Include(city => city.StartPoints)
                                     .Include(city => city.EndPoints)
                                     .SingleOrDefaultAsync(city => city.Id == id);

            return city;
        }
    }
}
