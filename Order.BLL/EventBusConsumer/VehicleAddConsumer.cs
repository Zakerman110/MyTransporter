using EventBus.Messages.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.EventBusConsumer
{
    public class VehicleAddConsumer : IConsumer<VehicleAddEvent>
    {
        public Task Consume(ConsumeContext<VehicleAddEvent> context)
        {
            Console.WriteLine("--> VehicleAddEvent");
            return Task.CompletedTask;
        }
    }
}
