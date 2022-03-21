using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Interfaces.IRepositories;

namespace Transport.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IModelRepository ModelRepository { get; }
        IVehicleRepository VehicleRepository { get; }

        Task Complete();
    }
}
