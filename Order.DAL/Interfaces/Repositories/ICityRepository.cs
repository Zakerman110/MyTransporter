using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Interfaces.Repositories
{
    public interface ICityRepository : IGenericRepository<City>
    {
        public Task<City> GetDetail(int id);
    }
}
