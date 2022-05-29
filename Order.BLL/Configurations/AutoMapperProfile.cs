using AutoMapper;
using EventBus.Messages.Events;
using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using Order.DAL.Entities;
using Order.Proto;
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
                    .ForMember(dest => dest.PlaceDate, opt => opt.MapFrom(src => ((DateTime)src.OrderDate).ToString("dd.MM.yyyy HH:mm")))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderStatus));
            CreateMap<VehicleAddEvent, Vehicle>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make));
            CreateMap<VehicleUpdateEvent, Vehicle>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make));
            CreateMap<GrpcVehicleModel, Vehicle>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make));

        }
    }
}
