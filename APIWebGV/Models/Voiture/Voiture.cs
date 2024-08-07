using System;

namespace APIWebGV.Models.garage
{
    public class Voiture
    {
        public Guid Id { get; set; }
        public string Marque { get; set; } // Make en français
        public string Modele { get; set; } // Model en français
        public int Annee { get; set; } // Year en français
        public Guid GarageId { get; set; }
        public Garage Garage { get; set; }
    }
}
