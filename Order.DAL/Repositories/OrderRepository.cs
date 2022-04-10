using Order.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Entities.Order>, IOrderRepository
    {
        public OrderRepository(MyTransporterOrderContext context) : base(context)
        {
        }
    }
}
