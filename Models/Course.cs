using System.ComponentModel.DataAnnotations;

namespace mi_proyecto.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del curso es obligatorio")]
        [Display(Name = "Nombre del Curso")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe asignar un profesor")]
        [Display(Name = "Profesor Asignado")]
        public int TeacherId { get; set; }

        [Display(Name = "Nombre del Profesor")]
        public string TeacherName { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "El número de estudiantes debe estar entre 0 y 100")]
        [Display(Name = "Número de Estudiantes")]
        public int StudentsCount { get; set; } = 0;
    }
}
