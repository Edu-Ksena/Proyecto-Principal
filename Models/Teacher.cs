using System.ComponentModel.DataAnnotations;

namespace mi_proyecto.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del Profesor")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La materia es obligatoria")]
        [Display(Name = "Materia")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Display(Name = "Teléfono")]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Iniciales")]
        public string Initials => string.IsNullOrEmpty(Name) ? "" : string.Join("", Name.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Select(s => s[0])).ToUpper().Substring(0, Math.Min(2, Name.Split(' ').Length));

        [Display(Name = "Color de Tarjeta")]
        public string BadgeColor { get; set; } = "#7E57C2"; // Color inicial por defecto
    }
}
