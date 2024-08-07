namespace APIWebGV.Models.garage
{
    public class UpdateVoitureRequest
    {
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
        public Guid GarageId { get; set; }
    }
}
