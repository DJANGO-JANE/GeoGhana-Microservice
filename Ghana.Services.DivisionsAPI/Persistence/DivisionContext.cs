using Ghana.Services.DivisionsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ghana.Services.DivisionsAPI.Persistence
{
    public class DivisionContext : DbContext
    {
        public DivisionContext(DbContextOptions<DivisionContext> options) : base(options)
        {
        }


        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Locality> Localities { get; set; }

        
    }
}
