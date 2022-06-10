using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Configurations
{
    public class MapperBuilder
    {
        public static IMapper Build()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            return new AutoMapper.Mapper(configuration);
        }
    }
}
