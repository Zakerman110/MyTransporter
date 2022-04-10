using Order.DAL.Interfaces;
using Order.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly MyTransporterOrderContext _transporterOrderContext;

        public UnitOfWork(MyTransporterOrderContext transporterOrderContext,
                          ICountryRepository countryRepository,
                          IRegionRepository regionRepository,
                          ICityRepository cityRepository,
                          IRouteRepository routeRepository,
                          IJourneyRepository journeyRepository,
                          IOrderRepository ordersRepository)
        {
            _transporterOrderContext = transporterOrderContext;
            CountryRepository = countryRepository;
            RegionRepository = regionRepository;
            CityRepository = cityRepository;
            RouteRepository = routeRepository;
            JourneyRepository = journeyRepository;
            OrdersRepository = ordersRepository;
        }

        public ICountryRepository CountryRepository { get; }

        public IRegionRepository RegionRepository { get; }

        public ICityRepository CityRepository { get; }

        public IRouteRepository RouteRepository { get; }

        public IJourneyRepository JourneyRepository { get; }

        public IOrderRepository OrdersRepository { get; }

        public async Task SaveChangesAsync() => await _transporterOrderContext.SaveChangesAsync();
    }
}
