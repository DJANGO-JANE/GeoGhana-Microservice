using AutoMapper;
using Ghana.Services.PopulationAPI.DTOs;
using Ghana.Services.PopulationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityViewDTO>()
                                        .ForMember(x => x.CityCode, y => y.MapFrom(z => z.CityCode));
            CreateMap<City, CityFullDTO>()
                                        .ForMember(x => x.Localities, y => y.MapFrom(z => z.Localities))
                                        .ForMember(x => x.RegionCode, y => y.MapFrom(z => z.Region.RegionCode));
            CreateMap<City, CityAsChildDTO>()
                                          .ForMember(x => x.Localities, y => y.MapFrom(z => z.Localities));
/*            CreateMap<City, CityUpdate>();
            CreateMap<CityUpdate, City>();*/
        }
    }

}
