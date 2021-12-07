using AutoMapper;
using Ghana.Services.DivisionsAPI.DTOs;
using Ghana.Services.DivisionsAPI.Models;

namespace Ghana.Services.DivisionsAPI.Profiles
{
    public class LocalityProfile : Profile
    {
        public LocalityProfile()
        {
            CreateMap<Locality, LocalityView>()
                                              .ForMember(x => x.CityCode, y => y.MapFrom(z => z.City.CityCode))
                                              .ForMember(x => x.RegionCode, y => y.MapFrom(z => z.Region.RegionCode))
                                              .ForMember(x => x.PostCode, y => y.MapFrom(z => z.Region));
            CreateMap<Locality, LocalityAsChild>()
                                                .ForMember(x => x.LocalityCode, y => y.MapFrom(z => z.LocalityCode))
                                                .ForMember(x => x.PostCode, y => y.MapFrom(z => z.ToString()));

            CreateMap<LocalityAdd, Locality>();
            CreateMap<Locality, LocalityUpdate>();
            CreateMap<LocalityUpdate, Locality>();

        }
    }
}
