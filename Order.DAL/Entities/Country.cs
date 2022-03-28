using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Region> Regions { get; set; }
    }
}
