using Order.DAL.Entities;
using Order.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.DTO.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string PlaceDate { get; set; }
        public OrderStatus Status { get; set; }
        public string UserId { get; set; }
        public Vehicle Vehicle { get; set; }
        public RouteResponse Route { get; set; }
        public JourneyResponse Journey { get; set; }
    }
}
