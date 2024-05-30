using System.ComponentModel.DataAnnotations;

namespace FQ24L007B.CrowdFunding.Api.DTO;

public class DonationCreateDto
{
    [Required]
    [Range(1, 999999999)]
    public int Montant { get; set; }
    
    public DateTime Date { get; set; }

    [Required]
    public int UtilisateurId { get; set; }
    
    [Required]
    public int ProjetId { get; set; }
}