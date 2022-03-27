using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.BLL.DTO.Request;
using Transport.BLL.DTO.Response;
using Transport.DAL.Entities;

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
        }
    }
}
