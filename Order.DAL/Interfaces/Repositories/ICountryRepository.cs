using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Interfaces.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        public Task<IEnumerable<Country>> GetDetail();
        public Task<Country> GetDetailById(int id);
    }
}
