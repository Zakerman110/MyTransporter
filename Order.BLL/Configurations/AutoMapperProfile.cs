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
        }
    }
}
