using AutoMapper;
using Ghana.Services.DivisionsAPI.DTOs;
using Ghana.Services.DivisionsAPI.Models;

namespace Ghana.Services.DivisionsAPI.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionView>()
                                        .ForMember(x =>x.NumberOfCities, y=>y.MapFrom(z=>z.Cities.Count))
                                        .ForMember(x => x.NumberOfLocalities, y => y.MapFrom(z => z.Localities.Count));
            CreateMap<Region, RegionFull>()
                                              .ForMember(x => x.Cities, x => x.MapFrom(z => z.Cities))
                                              ;
            //.ForSourceMember(src=>src.Cities)
            CreateMap<RegionAdd, Region>();
            CreateMap<Region, RegionFull>();
            CreateMap<Region, RegionUpdate>();
            CreateMap<RegionUpdate, Region>();
        }
    }
}
