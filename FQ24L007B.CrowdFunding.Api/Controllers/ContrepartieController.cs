using FQ24L007B.CrowdFunding.Api.DTO;
using FQ24L007B.CrowdFunding.Domain;
using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace FQ24L007B.CrowdFunding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContrepartieController : ControllerBase
    {
        private readonly CrowdFundingDbContext _context;

        public ContrepartieController(CrowdFundingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(ContrepartieCreateDto contrepartieCreate)
        {
            Projet? projet = _context.Projets.Find(contrepartieCreate.ProjetId);

            if (projet is null)
            {
                return NotFound("L'id du projet n'existe pas.");
            }
            
            try
            {
                Contrepartie contrepartie = new Contrepartie()
                {
                    Description = contrepartieCreate.Description,
                    Montant = contrepartieCreate.Montant,
                    ProjetId = contrepartieCreate.ProjetId
                };

                _context.Contreparties.Add(contrepartie);
                _context.SaveChanges();
                
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{contrepartieId}/projet/{projetId}")]
        public IActionResult Delete(int contrepartieId, int projetId)
        {
            Projet? projet = _context.Projets.Find(projetId);

            if (projet is null)
            {
                return NotFound("Projet non trouvé");
            }
            
            Contrepartie? contrepartie = _context.Contreparties.Find(contrepartieId);

            if (contrepartie is null)
            {
                return NotFound("Contrepartie non trouvée.");
            }

            List<Contrepartie> listeContrepartie = _context.Contreparties.ToList();

            if (listeContrepartie.Count == 1)
            {
                return BadRequest("Vous ne pouvez pas supprimer la dernière contrepartie de ce projet.");
            }

            _context.Contreparties.Remove(contrepartie);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}
