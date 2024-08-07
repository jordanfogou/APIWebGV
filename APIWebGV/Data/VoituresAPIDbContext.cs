// VoituresAPIDbContext.cs
using Microsoft.EntityFrameworkCore;
using APIWebGV.Models.garage; // Utilisez le namespace correct pour Voiture

namespace APIWebGV.Data
{
    public class VoituresAPIDbContext : DbContext
    {
        public VoituresAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Voiture> Voitures { get; set; }
    }
}
