using AutoMapper;
using Core.Infrastructure.Bus;
using Ghana.Services.PopulationAPI.Application.Features;
using Ghana.Services.PopulationAPI.Commands;
using Ghana.Services.PopulationAPI.Models;
using Ghana.Services.PopulationAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Repository
{
    public class PopulationRepository : IPopulationRepository
    {
        public readonly PopulationContext _context;
        private readonly IMapper _mapper;
        private readonly IEventBus _bus;

        public PopulationRepository(PopulationContext context, IEventBus bus, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _bus = bus;
        }

        public async Task<Population> AddPopulationData(Population population)
        {
            if (population != null)
            {
                var div = string.Empty;
                //var code = Int32.Parse(population.DivisionCode);

                if (population.DivisionCode[^1] == 'X')
                {
                    var region = new RegionAdditionCommand(population.DivisionCode);
                    _ = _bus.SendCommand(region);
                }
                else if(population.DivisionCode.Length == 2 && Regex.IsMatch(population.DivisionCode,@"^[a-zA-Z]+$"))
                {
                    var locality = new LocalityAdditionCommand(population.DivisionCode);
                    _ = _bus.SendCommand(locality);
                }
                else if(Regex.IsMatch(population.DivisionCode, @"^[0-9]+$"))
                {
                    var city = new CityAdditionCommand(population.DivisionCode);
                        _ = _bus.SendCommand(city);
                }


                _context.Population.Add(population);
                _ = await _context.SaveChangesAsync();
            }
            return await _context.Population.FirstOrDefaultAsync(z => z.DivisionCode == population.DivisionCode);
        }

        public async Task<List<Population>> GetThePopulation()
        {
            var results = await _context.Population.ToListAsync();
            return _mapper.Map<List<Population>>(results);
        }

        public async Task<Population> UpdatePopulationData(Population population)
        {
            if (await _context.Population.FindAsync(population.DivisionCode) != null)
            {
                if (population != null)
                {
                    _context.Population.Update(population);
                    _ = await _context.SaveChangesAsync();
                }
            }
            return await _context.Population.FirstOrDefaultAsync(z => z.DivisionCode == population.DivisionCode);
        }

        /*
                public async Task<T> LookFor(string code)
                {
                    if (!string.IsNullOrWhiteSpace(code))
                    {
                        return (T)await _context.Population.FirstOrDefaultAsync(z => z.DivisionCode == code);
                    }
                    throw new ApplicationException($"The parameter must not be empty.");
                }
                public async Task<T> Update(string code, T item)
                {
                    T division = (T)await _context.Population.FirstOrDefaultAsync(z => z.DivisionCode == item.DivisionCode);
                    if (division.DivisionCode.Length>1)
                    {
                        _context.Population.Update(item);
                        await _context.SaveChangesAsync();
                    }
                    return (T)await _context.Population.FirstOrDefaultAsync(z => z.DivisionCode == item.DivisionCode);
                }*/
    }
}
