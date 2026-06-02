using System.ComponentModel.DataAnnotations;

namespace mi_proyecto.Models
{
    public class VotingCandidate
    {
        public int Id { get; set; }
        
        [Required]
        public int VotingEventId { get; set; }
        
        [Required(ErrorMessage = "El nombre del candidato es obligatorio")]
        [Display(Name = "Nombre del Candidato")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "La propuesta es obligatoria")]
        [Display(Name = "Propuesta / Lema")]
        public string Proposal { get; set; } = string.Empty;
        
        [Display(Name = "Votos Obtenidos")]
        public int VotesCount { get; set; } = 0;
    }
}
