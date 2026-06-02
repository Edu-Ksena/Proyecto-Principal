namespace mi_proyecto.Models
{
    public class ScheduleSlot
    {
        public int Id { get; set; }
        public string Day { get; set; } = string.Empty; // Lunes, Martes, Miercoles, Jueves, Viernes
        public string TimeSlot { get; set; } = string.Empty; // 7:00-9:30, 9:30-12:30, 12:30-2:00
        public string Subject { get; set; } = string.Empty; // Matemáticas, Lenguaje, etc.
        public string Grade { get; set; } = string.Empty; // 9ª, 10ª, etc.
        public string Classroom { get; set; } = string.Empty; // aula 204
        public string TeacherName { get; set; } = string.Empty; // Prof. Morales
    }
}
