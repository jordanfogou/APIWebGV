using System;
using System.Collections.Generic;
using APIWebGV.Models.garage; // Assurez-vous que ce namespace est correct

namespace APIWebGV.Models.garage
{
    public class Garage
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty; // Name en français
        public string Emplacement { get; set; } = string.Empty; // Location en français
        public List<Voiture> Voitures { get; set; } = new List<Voiture>(); // Initialisation de la liste pour éviter les NullReferenceException
    }
}
