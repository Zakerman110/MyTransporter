﻿using Order.DAL.Enums;
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
        public DateTime PlaceDate { get; set; }
        public OrderStatus Status { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public RouteResponse Route { get; set; }
        public JourneyResponse Journey { get; set; }
    }
}
