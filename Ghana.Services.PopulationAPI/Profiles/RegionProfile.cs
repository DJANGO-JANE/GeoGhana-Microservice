using AutoMapper;
using Ghana.Services.PopulationAPI.DTOs;
using Ghana.Services.PopulationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionViewDTO>()
                                        .ForMember(x => x.NumberOfCities, y => y.MapFrom(z => z.Cities.Count))
                                        .ForMember(x => x.NumberOfLocalities, y => y.MapFrom(z => z.Localities.Count));
            CreateMap<Region, RegionFullDTO>()
                                              .ForMember(x => x.Cities, x => x.MapFrom(z => z.Cities))
                                              ;
            //.ForSourceMember(src=>src.Cities)
            CreateMap<Region, RegionFullDTO>();
/*            CreateMap<Region, RegionUpdate>();
            CreateMap<RegionUpdate, Region>();*/
        }
    }

}
