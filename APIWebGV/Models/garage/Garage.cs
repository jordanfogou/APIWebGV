using System;
using System.Collections.Generic;

namespace APIWebGV.Models.garage
{
    public class Garage
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Emplacement { get; set; }

        public List<APIWebGV.Models.voiture.Voiture> Voitures { get; set; } // Ajoutez le namespace complet pour Voiture

        public Garage()
        {
            Voitures = new List<APIWebGV.Models.voiture.Voiture>(); // Ajoutez le namespace complet pour Voiture
        }
    }
}
