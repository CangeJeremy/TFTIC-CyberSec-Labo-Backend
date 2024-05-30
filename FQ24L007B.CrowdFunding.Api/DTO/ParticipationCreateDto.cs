using System.ComponentModel.DataAnnotations;

namespace FQ24L007B.CrowdFunding.Api.DTO;

public class ParticipationCreateDto
{
    
    public DateTime Date { get; set; }
    
    [Required]
    public int UtilisateurId { get; set; }
    
    [Required]
    public int ContrepartieId { get; set; }
}