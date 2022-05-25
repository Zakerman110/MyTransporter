using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Order.BLL.Interfaces.Services;
using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.EventBusConsumer
{
    public class VehicleUpdateConsumer : IConsumer<VehicleUpdateEvent>
    {
        private readonly IVehicleService _service;
        private readonly IMapper _mapper;

        public VehicleUpdateConsumer(IVehicleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<VehicleUpdateEvent> context)
        {
            var vehicle = _mapper.Map<Vehicle>(context.Message);
            await _service.UpdateAsync(vehicle);
        }
    }
}
