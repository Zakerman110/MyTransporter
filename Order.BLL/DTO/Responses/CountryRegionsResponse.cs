using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.DTO.Responses
{
    public class CountryRegionsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<RegionResponse> Regions { get; set; }
    }
}
