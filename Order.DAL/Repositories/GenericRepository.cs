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
            return await _dbSet.FindAsync(id) ?? throw new NotFoundException($"{typeof(TEntity).Name} with id {id} not found.");
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var entities = await _dbSet.AsNoTracking().ToListAsync();

            if(entities is null)
            {
                throw new NotFoundException($"{typeof(TEntity).Name} not found.");
            }

            return entities;
        }

        public async Task Remove(int id)
        {
            var entity = await FindById(id);
            _dbSet.Remove(entity);
        }

        public async Task Update(TEntity item)
        {
            var entity = await FindById(item.Id);
            _context.Entry(entity).State = EntityState.Detached;
            await Task.Run(() => _dbSet.Update(item));
        }
    }
}
