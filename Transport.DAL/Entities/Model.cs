using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Interfaces.EntitiyInterface;

namespace Transport.DAL.Entities
{
    public class Model : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MakeId { get; set; }
    }
}
