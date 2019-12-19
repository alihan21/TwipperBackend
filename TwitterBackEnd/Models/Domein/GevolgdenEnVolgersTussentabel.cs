namespace TwitterBackEnd.Models.Domein
{
    public class GevolgdenEnVolgersTussentabel
    {
        public Gebruiker Volger { get; set; }
        public string VolgerId { get; set; }
        public Gebruiker Gevolgde { get; set; }
        public string GevolgdeId { get; set; }
        //public bool IsVolgersLijst { get; set; }
    }
}
