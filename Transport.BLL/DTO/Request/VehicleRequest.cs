using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Enums;

namespace Transport.BLL.DTO.Request
{
    public class VehicleRequest
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public VehicleType Type { get; set; }
        public string? Color { get; set; }
        public bool IsAvailable { get; set; }
        public int AutobaseId { get; set; }
        public int ModelId { get; set; }
    }
}
