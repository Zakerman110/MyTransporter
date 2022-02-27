using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Interfaces;
using Transport.DAL.Interfaces.IRepositories;

namespace Transport.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IModelRepository _modelRepository;

        public UnitOfWork(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public Task Complete()
        {
            throw new NotImplementedException();
        }

        public IModelRepository ModelRepository => _modelRepository;

    }
}
