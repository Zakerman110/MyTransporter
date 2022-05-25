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
        private readonly IMakeRepository _makeRepository;

        public UnitOfWork(IModelRepository modelRepository, 
                          IVehicleRepository vehicleRepository,
                          IMakeRepository makeRepository)
        {
            _modelRepository = modelRepository;
            _vehicleRepository = vehicleRepository;
            _makeRepository = makeRepository;
        }

        public Task Complete()
        {
            throw new NotImplementedException();
        }

        public IModelRepository ModelRepository => _modelRepository;
        public IVehicleRepository VehicleRepository => _vehicleRepository;
        public IMakeRepository MakeRepository => _makeRepository;

    }
}
