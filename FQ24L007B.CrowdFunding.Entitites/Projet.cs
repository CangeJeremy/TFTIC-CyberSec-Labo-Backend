using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQ24L007B.CrowdFunding.Entitites
{
    public class Projet
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public int Objectif { get; set; }
        public int UtilisateurId { get; set; }

        //Propriétés de navigation
        public virtual Utilisateur Utilisateur { get; set; } = default!;
        public virtual ICollection<Contrepartie> Contreparties { get; set; } = new List<Contrepartie>();
        public virtual IEnumerable<Donation> Donations { get; set; } = new List<Donation>();
    }
}
