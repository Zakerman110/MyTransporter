using AutoMapper;
using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CountryRequest, Country>();
            CreateMap<Country, CountryResponse>();
            CreateMap<Country, CountryRegionsResponse>();
            CreateMap<RegionRequest, Region>();
            CreateMap<Region, RegionResponse>();
            CreateMap<Region, RegionCitiesResponse>();
            CreateMap<CityRequest, City>();
            CreateMap<City, CityResponse>();
            CreateMap<RouteRequest, Route>();
            CreateMap<Route, RouteResponse>();
            CreateMap<JourneyRequest, Journey>();
            CreateMap<Journey, JourneyResponse>();
            CreateMap<OrderRequest, DAL.Entities.Order>();
            CreateMap<DAL.Entities.Order, OrderResponse>()
                    .ForMember(dest => dest.PlaceDate, opt => opt.MapFrom(src => src.OrderDate))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderStatus));
        }
    }
}
