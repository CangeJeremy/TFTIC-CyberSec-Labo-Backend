using System.ComponentModel.DataAnnotations;

namespace FQ24L007B.CrowdFunding.Api.DTO;

public class ProjetCreateDto
{
    [Required]
    [MinLength(3)]
    public required string Nom { get; set; }
    
    [Required]
    [Range(1000, 999999999)]
    public int Objectif { get; set; }
    
    [Required]
    public int UtilisateurId { get; set; }
}