using APIWebGV.Models.garage;
using APIWebGV.Models.voiture;
using Microsoft.EntityFrameworkCore;

namespace APIWebGV.Data
{
    public class GaragesAPIDbContext : DbContext
    {
        public GaragesAPIDbContext(DbContextOptions<GaragesAPIDbContext> options)
            : base(options)
        {
        }

        public DbSet<Garage> Garages { get; set; }
        public DbSet<Voiture> Voitures { get; set; }
    }
}
