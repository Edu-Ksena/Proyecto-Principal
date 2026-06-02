using System.ComponentModel.DataAnnotations;

namespace mi_proyecto.Models
{
    public class VotingEvent
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El título es obligatorio")]
        [Display(Name = "Título de Votación")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "La fecha y hora de inicio es obligatoria")]
        [Display(Name = "Fecha y Hora de Inicio")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "La fecha y hora de fin es obligatoria")]
        [Display(Name = "Fecha y Hora de Fin")]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
        
        public string Status 
        {
            get
            {
                var now = DateTime.Now;
                if (now < StartDate) return "Programada";
                if (now > EndDate) return "Finalizada";
                return "En Curso";
            }
        }
    }
}
