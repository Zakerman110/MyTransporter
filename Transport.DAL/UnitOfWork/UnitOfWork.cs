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
        private readonly IVehicleRepository _vehicleRepository;

        public UnitOfWork(IModelRepository modelRepository, IVehicleRepository vehicleRepository)
        {
            _modelRepository = modelRepository;
            _vehicleRepository = vehicleRepository;
        }

        public Task Complete()
        {
            throw new NotImplementedException();
        }

        public IModelRepository ModelRepository => _modelRepository;
        public IVehicleRepository VehicleRepository => _vehicleRepository;

    }
}
