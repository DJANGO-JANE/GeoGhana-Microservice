using Ghana.Services.PopulationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Persistence
{
    public class PopulationContext : DbContext
    {
        public PopulationContext(DbContextOptions<PopulationContext> options):base(options)
        {
                
        }

        public DbSet<Population> Population { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Locality> Localities { get; set; }
    }
}
