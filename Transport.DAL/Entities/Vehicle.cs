using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Interfaces.EntitiyInterface;
using Transport.DAL.Enums;

namespace Transport.DAL.Entities
{
    public class Vehicle : IEntity<int>
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public VehicleType Type { get; set; }
        public bool IsAvailable { get; set; }
        public int AutobaseId { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
    }
}
