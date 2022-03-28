using Order.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
    }
}
