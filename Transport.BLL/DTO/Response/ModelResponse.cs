using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.BLL.DTO.Response
{
    public class ModelResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //public int MakeId { get; set; }
        public MakeResponse? Make { get; set; }
    }
}
