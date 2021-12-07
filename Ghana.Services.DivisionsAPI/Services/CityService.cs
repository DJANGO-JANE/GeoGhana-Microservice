using AutoMapper;
using Ghana.Services.DivisionsAPI.Interfaces;
using Ghana.Services.DivisionsAPI.Models;
using Ghana.Services.DivisionsAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Services
{
    public class CityService : ICityRepository
    {
        private readonly DivisionContext _context;
        private readonly IMapper _mapper;

        public CityService(DivisionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddNewCity(City city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            //This just works. Tamper at your own risk
            Region region = _context.Regions.Single(r => r.Name == city.RegionName);
            City cityTemp = new City
            {
                Name = city.Name,
                RegionName = city.RegionName,
                Region = region,
                CityCode = city.CityCode
            };
            _context.Cities.Add(cityTemp);
        }

        public void DeleteCity(City city)
        {
            _context.Cities.Remove(city);
            
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<IEnumerable<Locality>> GetAllLocalities()
        {
            return await _context.Localities.ToListAsync();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<City> SearchCityByCode(int code)
        {
            var request = await _context.Cities
                                        .Include(x => x.Region)
                                        .Include(x => x.Localities)
                                        .FirstOrDefaultAsync(p => p.CityCode == code);
            return request;
        }

        public async Task<City> FindDuplicate(string name, string ?regionName)
        {
            var result = await _context.Cities
                                                .Include(x => x.Region)
                                                .SingleOrDefaultAsync(x => x.Name == name & x.Region.Name == regionName);
            return result;
        }

        public void UpdateCity(City city)
        {
        }

        public async Task<IEnumerable<City>> QueryCityName(string name)
        {
            var result = await _context.Cities
                                         .Where(x => x.Name.Contains(name)).ToListAsync();
            return result;
        }
    }
}
