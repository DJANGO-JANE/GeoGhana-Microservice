using Ghana.Services.DivisionsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ghana.Services.DivisionsAPI.Persistence
{
    public class DivisionContext : DbContext
    {
        public DivisionContext(DbContextOptions<DivisionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                                        .HasData(
                new Region { Name = "Ashanti", RegionCode = "ASX", CapitalCity = "Kumasi" },
                new Region { Name = "Greater Accra", RegionCode = "GRX", CapitalCity = "Accra" },
                new Region { Name = "Bono Region", RegionCode = "BNX", CapitalCity = "Sunyani" },
                new Region { Name = "Bono East Region", RegionCode = "BEX", CapitalCity = "Techiman" },
                new Region { Name = "Ahafo Region", RegionCode = "HAX", CapitalCity = "Goaso" },
                new Region { Name = "Central", RegionCode = "CNX", CapitalCity = "Cape Coast" },
                new Region { Name = "Eastern", RegionCode = "EAX", CapitalCity = "Koforidua" },
                new Region { Name = "Northern", RegionCode = "NRX", CapitalCity = "Tamale" },
                new Region { Name = "Savannah", RegionCode = "SVX", CapitalCity = "Damongo" },
                new Region { Name = "North East", RegionCode = "NEX", CapitalCity = "Nalerigu" },
                new Region { Name = "Upper West", RegionCode = "UWX", CapitalCity = "Wa" },
                new Region { Name = "Upper East", RegionCode = "UEX", CapitalCity = "Bolgatanga" },
                new Region { Name = "Volta Region", RegionCode = "VLX", CapitalCity = "Ho" },
                new Region { Name = "Oti", RegionCode = "OTX", CapitalCity = "Dambai" },
                new Region { Name = "Western Region", RegionCode = "WSX", CapitalCity = "Takoradi" },
                new Region { Name = "Western North", RegionCode = "WNX", CapitalCity = "Wiawso" }
                );

            modelBuilder.Entity<City>()
                                        .Property(a => a.CityCode).HasDefaultValueSql<int>("100");
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Locality> Localities { get; set; }

        
    }
}
