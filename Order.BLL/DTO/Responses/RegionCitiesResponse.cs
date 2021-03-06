using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.DTO.Responses
{
    public class RegionCitiesResponse
    {
        public string Name { get; set; }
        public CountryResponse Country { get; set; }
        public IEnumerable<CityResponse> Cities { get; set; }
    }
}
