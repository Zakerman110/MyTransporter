using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.DTO.Responses
{
    public class RouteResponse
    {
        public int Id { get; set; }
        public int? StartPointId { get; set; }
        public CityResponse? StartPoint { get; set; }
        public int? EndPointId { get; set; }
        public CityResponse? EndPoint { get; set; }
    }
}
