using AutoMapper;
using Ghana.Services.PopulationAPI.DTOs;
using Ghana.Services.PopulationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Profiles
{
    public class PopulationProfile : Profile
    {
        public PopulationProfile()
        {

            CreateMap<PopulationAddDTO, Population>().ReverseMap();
            CreateMap<Population, PopulationLiteDTO>();

            CreateMap<Population, RegionViewDTO>();
            CreateMap<Population, Region>().ReverseMap();
            CreateMap<Population, RegionAdd>().ReverseMap();

            CreateMap<Population, CityViewDTO>();
            CreateMap<Population, City>().ReverseMap();
            CreateMap<Population, CityAdd>().ReverseMap();

            CreateMap<Population, LocalityViewDTO>();
            CreateMap<Population, Locality>().ReverseMap();
            CreateMap<Population, LocalityAdd>().ReverseMap();

        }
    }
}
