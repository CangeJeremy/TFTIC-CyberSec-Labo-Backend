using FQ24L007B.CrowdFunding.Api.DTO;
using FQ24L007B.CrowdFunding.Domain;
using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace FQ24L007B.CrowdFunding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly CrowdFundingDbContext _context;

        public UtilisateurController(CrowdFundingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(UtilisateurCreateDto utilisateurCreate)
        {
            try
            {
                Utilisateur utilisateur = new Utilisateur()
                {
                    Nom = utilisateurCreate.Nom,
                    Email = utilisateurCreate.Email
                };
                
                _context.Utilisateurs.Add(utilisateur);
                _context.SaveChanges();
                
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [HttpPatch]
        public IActionResult Update(UtilisateurUpdateDto utilisateurUpdate)
        {
            Utilisateur? u = _context.Utilisateurs.Find(utilisateurUpdate.Id);

            if (u is null)
            {
                return NotFound("Utilisateur non trouvé.");
            }

            u.Email = utilisateurUpdate.Email;
            
            _context.Utilisateurs.Update(u);
            _context.SaveChanges();

            return Ok(u);
        }
    }
}
