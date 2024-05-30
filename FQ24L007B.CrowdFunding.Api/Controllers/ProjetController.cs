using FQ24L007B.CrowdFunding.Api.DTO;
using FQ24L007B.CrowdFunding.Domain;
using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FQ24L007B.CrowdFunding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetController : ControllerBase
    {
        private readonly CrowdFundingDbContext _context;

        public ProjetController(CrowdFundingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // Fix temporaire - Réglé via program.cs -- .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            /*
             var projets = _context.Projets
                .Include(p => p.Utilisateur)
                .Select(p => new 
                {
                    Id = p.Id,
                    Nom = p.Nom,
                    Objectif = p.Objectif,
                    Utilisateur = new 
                    {
                        Id = p.Utilisateur.Id,
                        Nom = p.Utilisateur.Nom,
                        Email = p.Utilisateur.Email
                    },
                    Contreparties = p.Contreparties,
                    Donation = p.Donations
                });
            */

            List<Projet> projets = _context.Projets.ToList();
            
            return Ok(projets);
        }
        
        [HttpGet("{userId}")]
        public IActionResult GetProjectByUserId(int userId)
        {
            List<Projet> projets = _context.Projets.Where(p => p.UtilisateurId == userId).ToList();

            return Ok(projets);
        }

        [HttpPost]
        public IActionResult Create(ProjetCreateDto projetCreate)
        {
            Utilisateur? utilisateur = _context.Utilisateurs.Find(projetCreate.UtilisateurId);

            if (utilisateur is null)
            {
                return BadRequest("L'id utilisateur n'existe pas.");
            }
            
            try
            {
                Projet projet = new Projet()
                {
                    Nom = projetCreate.Nom,
                    Objectif = projetCreate.Objectif,
                    UtilisateurId = projetCreate.UtilisateurId
                };
                
                _context.Projets.Add(projet);
                _context.SaveChanges();
                
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public IActionResult Update(ProjetUpdateDto projetUpdate)
        {
            Projet? projet = _context.Projets.Find(projetUpdate.Id);

            if (projet is null)
            {
                return NotFound("Projet non trouvé.");
            }

            projet.Nom = projetUpdate.Nom;
            
            _context.Projets.Update(projet);
            _context.SaveChanges();

            return Ok(projet);
        }
    }
}
