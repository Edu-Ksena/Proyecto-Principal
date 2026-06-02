using System.ComponentModel.DataAnnotations;

namespace mi_proyecto.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del estudiante es obligatorio")]
        [Display(Name = "Nombre completo")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El grado es obligatorio")]
        [Display(Name = "Grado")]
        public string Grade { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Display(Name = "Estado")]
        public string Status { get; set; } = "Activo"; // Activo, Inactivo

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico no válido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; } = string.Empty;
    }
}
