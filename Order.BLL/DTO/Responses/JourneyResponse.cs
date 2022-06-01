using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.DTO.Responses
{
    public class JourneyResponse
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
