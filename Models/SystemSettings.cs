using System.ComponentModel.DataAnnotations;

namespace mi_proyecto.Models
{
    public class SystemSettings
    {
        [Required(ErrorMessage = "El nombre del colegio es obligatorio")]
        [Display(Name = "Nombre del colegio")]
        public string SchoolName { get; set; } = "Colegio educativo San Luis";

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [Display(Name = "Dirección")]
        public string Address { get; set; } = "A.principal 1123,Bogota";

        [Required(ErrorMessage = "El teléfono del colegio es obligatorio")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; } = "311 507 3457";

        [Required(ErrorMessage = "El correo del colegio es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        [Display(Name = "Correo Institucional")]
        public string SchoolEmail { get; set; } = "CESanLuis@gmail.com";

        [Required(ErrorMessage = "El nombre del administrador es obligatorio")]
        [Display(Name = "Nombre del Administrador")]
        public string AdminName { get; set; } = "Andres Ramirez";

        [Required(ErrorMessage = "El correo del administrador es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        [Display(Name = "Correo del Administrador")]
        public string AdminEmail { get; set; } = "AndresRamires4323@gmail.com";

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string CurrentPassword { get; set; } = "************";

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña Nueva")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La contraseña nueva y la de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
