using System.ComponentModel.DataAnnotations;

namespace FQ24L007B.CrowdFunding.Api.DTO;

public class ProjetUpdateDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MinLength(3)]
    public required string Nom { get; set; }
}