using System.ComponentModel.DataAnnotations;

namespace FQ24L007B.CrowdFunding.Api.DTO;

public class UtilisateurUpdateDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
}