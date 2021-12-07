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
    public class RegionService : IRegionRepository
    {
        private readonly DivisionContext _context;

        public RegionService(DivisionContext context)
        {
            _context = context;
        }

        public void AddNewRegion(Region region)
        {
            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }
            region.RegionCode = region.RegionCode.ToUpper();
            region.RegionCode += "X";
            _context.Regions.Add(region);
        }

        public void DeleteRegion(Region region)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<City>> GetAllCities(string region)
        {
           return (IEnumerable<City>)await _context.Cities.FindAsync(
                                                    _context.Regions
                                                    .Include(region => region.RegionCode)
                                                    .ToListAsync());
        }

        public IEnumerable<Locality> GetAllLocalities(Region region)
        {
            return _context.Localities.ToList();
        }

        public async Task<IEnumerable<Region>> GetAllRegions()
        {
            var results = await _context.Regions
                         .Include(x => x.Cities)
                         .Include(x => x.Localities)
                         .ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Region>> QueryRegionName(string regionName)
        {
            var result = await _context.Regions
                                        .Include(x => x.Cities)
                                        .Include(x => x.Localities)
                                        .Where(x => x.Name.Contains(regionName)).ToListAsync();
           return result;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<Region> SearchRegionByCode(string regionCode)
        {
            var result = await _context.Regions
                            .Include(p => p.Cities)
                                 .Where(p => p.RegionCode == regionCode)
                            .Include(r => r.Localities)
                            .FirstOrDefaultAsync();

            return result;
        }



        public void UpdateRegion(Region region)
        {
        }
    }
}
