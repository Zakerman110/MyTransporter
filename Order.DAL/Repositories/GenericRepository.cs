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
        public Task Create(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Remove(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
