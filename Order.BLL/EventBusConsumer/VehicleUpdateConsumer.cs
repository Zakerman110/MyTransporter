using EventBus.Messages.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.EventBusConsumer
{
    public class VehicleUpdateConsumer : IConsumer<VehicleUpdateEvent>
    {
        public Task Consume(ConsumeContext<VehicleUpdateEvent> context)
        {
            Console.WriteLine("--> VehicleUpdateEvent");
            return Task.CompletedTask;
        }
    }
}
