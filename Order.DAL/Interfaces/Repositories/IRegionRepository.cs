using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Interfaces.Repositories
{
    public interface IRegionRepository : IGenericRepository<Region>
    {
        public Task<Region> GetDetail(int id);
    }
}
