using System.ComponentModel.DataAnnotations;

namespace FQ24L007B.CrowdFunding.Api.DTO;

public class ContrepartieCreateDto
{
    [Required]
    [MinLength(1)]
    public required string Description { get; set; }
    
    [Required]
    [Range(1, 999999999)]
    public int Montant { get; set; }
    
    [Required]
    public int ProjetId { get; set; }
    
    [Required]
    public int UtilisateurId { get; set; }
}