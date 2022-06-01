using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Entities.Order>
    {
        public Task<Entities.Order> GetDetail(int id);
        public Task<IEnumerable<Entities.Order>> GetComplete();
        public Task<IEnumerable<Entities.Order>> GetByVehicleId(int id);
        public Task<IEnumerable<Entities.Order>> GetCompleteByUserId(string id);
        public Task<IEnumerable<Vehicle>> GetVehiclesFreeOnDate(DateTime date);
    }
}
