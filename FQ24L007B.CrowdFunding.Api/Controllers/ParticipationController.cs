using FQ24L007B.CrowdFunding.Api.DTO;
using FQ24L007B.CrowdFunding.Domain;
using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FQ24L007B.CrowdFunding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipationController : ControllerBase
    {
        private readonly CrowdFundingDbContext _context;

        public ParticipationController(CrowdFundingDbContext context)
        {
            _context = context;
        }

        [HttpGet("{projetId}")]
        public IActionResult GetParticipationByProjectId(int projetId)
        {
            var participations = _context.Projets
                .Where(p => p.Id == projetId)
                .SelectMany(p => p.Contreparties)
                .SelectMany(c => c.Participations)
                .ToList();
            
            return Ok(participations);
        }

        [HttpPost]
        public IActionResult Create(ParticipationCreateDto participationCreate)
        {
            Utilisateur? utilisateur = _context.Utilisateurs.Find(participationCreate.UtilisateurId);

            if (utilisateur is null)
            {
                return NotFound("Utilisateur non trouvé.");
            }
            
            Contrepartie? contrepartie = _context.Contreparties.Find(participationCreate.ContrepartieId);

            if (contrepartie is null)
            {
                return NotFound("Contrepartie non trouvée.");
            }

            Participation participation = new Participation()
            {
                Date = participationCreate.Date,
                UtilisateurId = participationCreate.UtilisateurId,
                ContrepartieId = participationCreate.ContrepartieId
            };

            _context.Participations.Add(participation);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}
