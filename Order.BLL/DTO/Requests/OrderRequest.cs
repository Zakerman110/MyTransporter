using Order.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.DTO.Requests
{
    public class OrderRequest
    {
        public string UserId { get; set; }
        public int VehicleId { get; set; }
        public int StartPointId { get; set; }
        public int EndPointId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
