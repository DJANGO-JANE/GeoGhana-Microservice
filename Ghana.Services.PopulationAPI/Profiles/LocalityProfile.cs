using AutoMapper;
using Ghana.Services.PopulationAPI.DTOs;
using Ghana.Services.PopulationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Profiles
{
    public class LocalityProfile : Profile
    {
        public LocalityProfile()
        {
            CreateMap<Locality, LocalityViewDTO>()
                                              .ForMember(x => x.CityCode, y => y.MapFrom(z => z.City.CityCode))
                                              .ForMember(x => x.RegionCode, y => y.MapFrom(z => z.Region.RegionCode))
                                              .ForMember(x => x.PostCode, y => y.MapFrom(z => z.Region));
            CreateMap<Locality, LocalityAsChildDTO>()
                                                .ForMember(x => x.LocalityCode, y => y.MapFrom(z => z.LocalityCode))
                                                .ForMember(x => x.PostCode, y => y.MapFrom(z => z.ToString()));

/*            CreateMap<LocalityAdd, Locality>();
            CreateMap<Locality, LocalityUpdate>();
            CreateMap<LocalityUpdate, Locality>();*/

        }
    }

}
