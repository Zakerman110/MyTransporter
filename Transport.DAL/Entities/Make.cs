using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Interfaces.EntitiyInterface;

namespace Transport.DAL.Entities
{
    public class Make : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public IEnumerable<Model>? Models { get; set; }
    }
}
