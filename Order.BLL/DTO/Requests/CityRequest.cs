﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.DTO.Requests
{
    public class CityRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
    }
}
