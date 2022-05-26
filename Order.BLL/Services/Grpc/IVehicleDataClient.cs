using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Services.Grpc
{
    public interface IVehicleDataClient
    {
        Task<IEnumerable<Vehicle>> ReturnAllVehicles();
    }
}
