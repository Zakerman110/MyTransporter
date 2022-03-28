using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Enums
{
    public enum OrderStatus
    {
        ORDERED,
        PENDING,
        IN_PROGRESS,
        COMPLETED,
        CANCELED
    }
}
