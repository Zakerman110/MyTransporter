using Microsoft.EntityFrameworkCore;
using Order.DAL.Entities;
using Order.DAL.Exceptions;
using Order.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(MyTransporterOrderContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Country>> GetDetail() => 
            await _dbSet.Include(country => country.Regions).ToListAsync() 
                ?? throw new NotFoundException($"{typeof(Country).Name} not found.");

        public async Task<Country> GetDetailById(int id) =>
            await _dbSet.Include(country => country.Regions).SingleOrDefaultAsync(country => country.Id == id) 
                ?? throw new NotFoundException($"{typeof(Country).Name} with id {id} not found.");
    }
}
