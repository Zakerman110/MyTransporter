using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.BLL.DTO.Request
{
    public class ModelRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MakeId { get; set; }
    }
}
