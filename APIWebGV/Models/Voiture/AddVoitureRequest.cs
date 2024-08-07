using APIWebGV.Models.garage;

namespace APIWebGV.Models.Voiture
{
    public class AddVoitureRequest
    {
        public string Marque { get; set; } 
        public string Modele { get; set; } 
        public int Annee { get; set; } 
        public Guid GarageId { get; set; }
        
    }
}
