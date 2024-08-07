using APIWebGV.Models.voiture; // Assurez-vous d'importer le namespace correct pour Voiture
using APIWebGV.Models.garage; // Assurez-vous d'importer le namespace correct pour Garage
using Microsoft.EntityFrameworkCore;

namespace APIWebGV.Data
{
    public class VoituresAPIDbContext : DbContext
    {
        public VoituresAPIDbContext(DbContextOptions<VoituresAPIDbContext> options)
            : base(options)
        {
        }

        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Garage> Garages { get; set; } // Ajout de la DbSet pour Garages
    }
}
