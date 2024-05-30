using FQ24L007B.CrowdFunding.Api.DTO;
using FQ24L007B.CrowdFunding.Domain;
using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FQ24L007B.CrowdFunding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly CrowdFundingDbContext _context;

        public DonationController(CrowdFundingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(DonationCreateDto donationCreate)
        {
            Projet? projet = _context.Projets.Find(donationCreate.ProjetId);

            if (projet is null)
            {
                return BadRequest("Le projet n'existe pas.");
            }
            
            try
            {
                Donation donation = new Donation()
                {
                    Montant = donationCreate.Montant,
                    Date = DateTime.Now,
                    UtilisateurId = donationCreate.UtilisateurId,
                    ProjetId = donationCreate.ProjetId
                };

                _context.Donations.Add(donation);
                _context.SaveChanges();
                
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{projetId}")]
        public IActionResult GetAllByProjectId(int projetId)
        {
            Projet? projet = _context.Projets.Find(projetId);

            if (projet is null)
            {
                return NotFound("Projet non trouvé.");
            }
            
            //Fonctionne mais ne correspond pas à la requête attendue ? Ca retourne bel et bien les donations basée sur le projetId
            /*var donation = _context.Projets
                .Where(p => p.Id == projetId)
                .SelectMany(p => p.Donations);*/
            
            // _context.Projects.Find(projectId)?.Select(p => p.Donations) me retourne une erreur sur le .Select : "Cannot resolve symbol 'Select'"
            // La seule chose que j'ai trouvé pour contourner le soucis en restant propre, est d'utiliser la ligne ci-dessous qui s'assure du chargement des donations en me basant sur le projet qui est récupéré en haut.
            _context.Entry(projet).Collection(p => p.Donations).Load();

            var donation = projet?.Donations;
            
            return Ok(donation);
        }
    }
}
