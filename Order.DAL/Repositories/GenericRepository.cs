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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MyTransporterOrderContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(MyTransporterOrderContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task Create(TEntity item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task Remove(int id)
        {
            var entity = await FindById(id);
            _dbSet.Remove(entity);
        }

        public async Task Update(TEntity item)
        {
            await Task.Run(() => _dbSet.Update(item));
        }
    }
}
