using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.DTO.Requests
{
    public class RouteRequest
    {
        public int Id { get; set; }
        public int? StartPointId { get; set; }
        public int? EndPointId { get; set; }
    }
}
