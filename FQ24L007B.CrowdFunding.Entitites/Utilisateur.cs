namespace FQ24L007B.CrowdFunding.Entitites
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Email { get; set; }

        //Propriété de navigation
        public virtual IEnumerable<Projet> Projets { get; set; } = new List<Projet>();
        public virtual IEnumerable<Participation> Participations { get; set; } = new List<Participation>();
        public virtual IEnumerable<Donation> Donations { get; set; } = new List<Donation>();
    }
}
