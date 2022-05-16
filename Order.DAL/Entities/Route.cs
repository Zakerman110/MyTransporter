using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Entities
{
    public  class Route : BaseEntity
    {
        public int? StartPointId { get; set; }
        public City? StartPoint { get; set; }
        public int? EndPointId { get; set; }
        public City? EndPoint { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
    }
}
