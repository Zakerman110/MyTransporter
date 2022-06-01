using Order.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.DTO.Requests
{
    public class OrderEditRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime PlaceDate { get; set; }
        public int VehicleId { get; set; }
        public OrderStatus Status { get; set; }
        public int StartPointId { get; set; }
        public int EndPointId { get; set; }
        public int JourneyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
