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
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        public RegionRepository(MyTransporterOrderContext context) : base(context)
        {
        }

        public async Task<Region> GetDetail(int id)
        {
            var region = await _dbSet.Include(region => region.Country)
                                     .Include(region => region.Cities)
                                     .SingleOrDefaultAsync(region => region.Id == id);

            return region;
        }
    }
}
