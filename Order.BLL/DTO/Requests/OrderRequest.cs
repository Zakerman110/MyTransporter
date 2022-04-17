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
        public int Id { get; set; }
        public DateTime PlaceDate { get; set; }
        public OrderStatus Status { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public int RouteId { get; set; }
        public int JourneyId { get; set; }
    }
}
