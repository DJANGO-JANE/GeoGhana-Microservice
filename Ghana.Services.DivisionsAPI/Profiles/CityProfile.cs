using AutoMapper;
using Ghana.Services.DivisionsAPI.DTOs;
using Ghana.Services.DivisionsAPI.Models;

namespace Ghana.Services.DivisionsAPI.Profiles
{
    public class CityProfile : Profile
    {
            public CityProfile()
            {
                CreateMap<City, CityView>()
                                            .ForMember(x => x.CityCode, y => y.MapFrom(z => z.CityCode));
                CreateMap<CityAdd, City>();
                CreateMap<City, CityFull>()
                                            .ForMember(x => x.Localities, y => y.MapFrom(z => z.Localities))
                                            .ForMember(x => x.RegionCode, y => y.MapFrom(z => z.Region.RegionCode));
                CreateMap<City, CityAsChild>()
                                              .ForMember(x => x.Localities, y => y.MapFrom(z => z.Localities));
                CreateMap<City, CityUpdate>();
                CreateMap<CityUpdate, City>();
            }
    }
}
