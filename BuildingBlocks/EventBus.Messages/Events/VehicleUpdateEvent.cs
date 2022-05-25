using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class VehicleUpdateEvent : IntegrationBaseEvent
    {
        public int ExternalId { get; set; }
        public string? Plate { get; set; }
        public string? Color { get; set; }
        public string? Model { get; set; }
        public string? Make { get; set; }
    }
}
