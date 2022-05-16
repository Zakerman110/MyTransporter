using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public IEnumerable<Route> StartPoints { get; set; }
        public IEnumerable<Route> EndPoints { get; set; }
    }
}
