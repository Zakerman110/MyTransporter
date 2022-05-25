using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Enums;

namespace Transport.BLL.DTO.Response
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public VehicleType Type { get; set; }
        public string? Color { get; set; }
        public bool IsAvailable { get; set; }
    }
}
