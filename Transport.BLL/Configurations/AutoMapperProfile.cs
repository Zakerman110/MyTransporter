using AutoMapper;
using EventBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.BLL.DTO.Request;
using Transport.BLL.DTO.Response;
using Transport.DAL.Entities;
using Transport.Proto;

namespace Transport.BLL.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Model, ModelResponse>();
            CreateMap<Model, ModelMakeResponse>();
            CreateMap<Make, MakeResponse>();
            CreateMap<ModelRequest, Model>();
            CreateMap<Vehicle, VehicleAddEvent>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(opt => opt.Model.Name))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(opt => opt.Model.Make.Name));
            CreateMap<Vehicle, VehicleUpdateEvent>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(opt => opt.Model.Name))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(opt => opt.Model.Make.Name));
            CreateMap<Vehicle, GrpcVehicleModel>()
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Name))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Model.Make.Name));

        }
    }
}
