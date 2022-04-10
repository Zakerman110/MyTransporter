using Order.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICountryRepository CountryRepository { get; }
        IRegionRepository RegionRepository { get; }
        ICityRepository CityRepository { get; }
        IRouteRepository RouteRepository { get; }
        IJourneyRepository JourneyRepository { get; }
        IOrderRepository OrdersRepository { get; }

        Task SaveChangesAsync();
    }
}
