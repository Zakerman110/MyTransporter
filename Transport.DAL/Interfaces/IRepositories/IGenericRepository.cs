using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Interfaces.EntitiyInterface;

namespace Transport.DAL.Interfaces.IRepositories
{
    public interface IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(TId Id);

        Task<int> Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}
