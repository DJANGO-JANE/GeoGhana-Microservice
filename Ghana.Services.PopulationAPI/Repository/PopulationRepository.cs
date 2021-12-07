using AutoMapper;
using Ghana.Services.PopulationAPI.DTOs;
using Ghana.Services.PopulationAPI.Models;
using Ghana.Services.PopulationAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Repository
{
    public class PopulationRepository : IPopulationRepository
    {
        public readonly PopulationContext _context;
        private readonly IMapper _mapper;

        public PopulationRepository(PopulationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Population> AddPopulationData(Population population)
        {
            if (population != null)
            {
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
