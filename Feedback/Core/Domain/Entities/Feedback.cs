using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
