namespace FQ24L007B.CrowdFunding.Entitites
{
    public class Contrepartie
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public int Montant { get; set; }
        public int ProjetId { get; set; }

        //Propriétés de navigation
        public virtual IEnumerable<Participation> Participations { get; set; } = new List<Participation>();
    }
}
