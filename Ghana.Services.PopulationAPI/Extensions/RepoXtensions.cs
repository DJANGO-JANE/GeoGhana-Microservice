using Ghana.Services.PopulationAPI.Models;
using Ghana.Services.PopulationAPI.Persistence;
using Ghana.Services.PopulationAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Extensions
{
    public static class RepoXtensions
    {
        public static PopulationContext _context { get; set; }
        //public static async Task<TEntity> CreateAsync<TEntity>(this IPopulationRepository repository, TEntity data) where TEntity: Population
        //{
        //    var item = new Population();
        //    if (data != null)
        //    {
        //        _context = (PopulationContext)repository;
        //        _context.Population.Add(data);
        //        _ =  await _context.SaveChangesAsync();
        //    }
        //    return (TEntity)await _context.Population.FirstOrDefaultAsync(z => z.DivisionCode == data.DivisionCode);
        //}

        //public static async Task<TEntity> UpdateAsync<TEntity>(this IPopulationRepository repository, TEntity data) where TEntity : Population
        //{
        //    if (await _context.Population.FindAsync(data.DivisionCode) != null)
        //    {
        //        if (data != null)
        //        {
        //            _context.Population.Update(data);
        //            _ = await _context.SaveChangesAsync();
        //        } 
        //    }
        //    return (TEntity)await _context.Population.FirstOrDefaultAsync(z => z.DivisionCode == data.DivisionCode);
        //}
    }
}
