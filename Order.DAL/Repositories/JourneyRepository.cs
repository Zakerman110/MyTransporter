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
    public class JourneyRepository : GenericRepository<Journey>, IJourneyRepository
    {
        public JourneyRepository(MyTransporterOrderContext context) : base(context)
        {
        }
        public async Task<Journey> GetDetail(int id)
        {
            var journey = await _dbSet.Include(journey => journey.Orders)
                                     .SingleOrDefaultAsync(journey => journey.Id == id);

            return journey;
        }
    }
}
