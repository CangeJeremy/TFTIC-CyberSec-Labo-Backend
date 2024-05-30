using System.ComponentModel.DataAnnotations;

namespace FQ24L007B.CrowdFunding.Api.DTO;

public class UtilisateurCreateDto
{
    [Required]
    [MinLength(1)]
    public required string Nom { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
}