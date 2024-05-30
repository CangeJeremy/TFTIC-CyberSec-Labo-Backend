namespace FQ24L007B.CrowdFunding.Entitites
{
    public class Participation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UtilisateurId { get; set; }
        public int ContrepartieId { get; set; }

        //Propriétés de navigation
        public Utilisateur Utilisateur { get; set; } = default!;
        public Contrepartie Contrepartie { get; set; } = default!;
    }
}
