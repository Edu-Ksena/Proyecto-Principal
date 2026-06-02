using System.Collections.Generic;
using System.Linq;
using mi_proyecto.Models;

namespace mi_proyecto.Services
{
    public class DataService
    {
        private readonly List<Teacher> _teachers = new();
        private readonly List<Student> _students = new();
        private readonly List<Course> _courses = new();
        private readonly List<ScheduleSlot> _scheduleSlots = new();
        private readonly List<VotingEvent> _votingEvents = new();
        private readonly List<VotingCandidate> _votingCandidates = new();
        private SystemSettings _settings = new();

        public DataService()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // 1. Inicializar Profesores
            _teachers.AddRange(new[]
            {
                new Teacher { Id = 1, Name = "Jorge Morales", Subject = "Matematicas", Phone = "321 796 854", BadgeColor = "#7E57C2" },
                new Teacher { Id = 2, Name = "Ana Maria Rios", Subject = "Español", Phone = "311 098 657", BadgeColor = "#AB47BC" },
                new Teacher { Id = 3, Name = "Luis Gomez", Subject = "Etica", Phone = "345 785 439", BadgeColor = "#5C6BC0" },
                new Teacher { Id = 4, Name = "Carlos Pinto", Subject = "Fisica", Phone = "300 789 531", BadgeColor = "#26A69A" },
                new Teacher { Id = 5, Name = "Mario Herrera", Subject = "Sociales", Phone = "398 731 246", BadgeColor = "#EC407A" },
                new Teacher { Id = 6, Name = "Daniel Gusman", Subject = "ED.fisica", Phone = "310 963 421", BadgeColor = "#26C6DA" }
            });

            // 2. Inicializar Estudiantes
            _students.AddRange(new[]
            {
                new Student { Id = 1, Name = "Alejandro Ruiz", Grade = "9ª", Status = "Activo", Email = "alejo.ruiz@eduk.edu.co" },
                new Student { Id = 2, Name = "Beatriz Gomez", Grade = "10ª", Status = "Activo", Email = "beatriz.g@eduk.edu.co" },
                new Student { Id = 3, Name = "Camilo Torres", Grade = "11ª", Status = "Activo", Email = "camilo.t@eduk.edu.co" },
                new Student { Id = 4, Name = "Diana Prada", Grade = "8ª", Status = "Activo", Email = "diana.p@eduk.edu.co" },
                new Student { Id = 5, Name = "Esteban Lopez", Grade = "7ª", Status = "Activo", Email = "esteban.l@eduk.edu.co" },
                new Student { Id = 6, Name = "Felipe Rueda", Grade = "9ª", Status = "Activo", Email = "felipe.r@eduk.edu.co" },
                new Student { Id = 7, Name = "Gabriela Castro", Grade = "10ª", Status = "Activo", Email = "gabriela.c@eduk.edu.co" },
                new Student { Id = 8, Name = "Hugo Sanchez", Grade = "11ª", Status = "Inactivo", Email = "hugo.s@eduk.edu.co" }
            });

            // 3. Inicializar Cursos
            _courses.AddRange(new[]
            {
                new Course { Id = 1, Name = "Noveno A-9ª", TeacherId = 1, TeacherName = "Jorge Morales", StudentsCount = 28 },
                new Course { Id = 2, Name = "Decimo A-10ª", TeacherId = 2, TeacherName = "Ana Maria Rios", StudentsCount = 32 },
                new Course { Id = 3, Name = "Octavo A-8ª", TeacherId = 3, TeacherName = "Luis Gomez", StudentsCount = 30 },
                new Course { Id = 4, Name = "Decimo B-10B", TeacherId = 4, TeacherName = "Carlos Pinto", StudentsCount = 25 },
                new Course { Id = 5, Name = "Septimo A-7ª", TeacherId = 5, TeacherName = "Mario Herrera", StudentsCount = 27 },
                new Course { Id = 6, Name = "Once A-11ª", TeacherId = 6, TeacherName = "Daniel Gusman", StudentsCount = 26 }
            });

            // 4. Inicializar Horarios
            // 7:00 - 9:30
            _scheduleSlots.Add(new ScheduleSlot { Id = 1, Day = "Lunes", TimeSlot = "7:00-9:30", Subject = "Matematicas", Grade = "9ª", Classroom = "aula 204", TeacherName = "Prof.Morales" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 2, Day = "Martes", TimeSlot = "7:00-9:30", Subject = "Lenguaje", Grade = "9ª", Classroom = "aula 204", TeacherName = "Prof.Rios" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 3, Day = "Miercoles", TimeSlot = "7:00-9:30", Subject = "Fisica", Grade = "9ª", Classroom = "aula 204", TeacherName = "Prof.Pinto" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 4, Day = "Jueves", TimeSlot = "7:00-9:30", Subject = "Sociales", Grade = "9ª", Classroom = "aula 201", TeacherName = "Prof.Herrera" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 5, Day = "Viernes", TimeSlot = "7:00-9:30", Subject = "Informatica", Grade = "9ª", Classroom = "aula 203", TeacherName = "Prof.Gusman" });

            // 9:30 - 12:30
            _scheduleSlots.Add(new ScheduleSlot { Id = 6, Day = "Lunes", TimeSlot = "9:30-12:30", Subject = "Lenguaje", Grade = "10ª", Classroom = "aula 201", TeacherName = "Prof.Rios" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 7, Day = "Martes", TimeSlot = "9:30-12:30", Subject = "Matematicas", Grade = "10ª", Classroom = "aula 304", TeacherName = "Prof.Morales" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 8, Day = "Miercoles", TimeSlot = "9:30-12:30", Subject = "Informatica", Grade = "10ª", Classroom = "aula 404", TeacherName = "Prof.Gusman" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 9, Day = "Jueves", TimeSlot = "9:30-12:30", Subject = "Sociales", Grade = "10ª", Classroom = "aula 205", TeacherName = "Prof.Herrera" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 10, Day = "Viernes", TimeSlot = "9:30-12:30", Subject = "Fisica", Grade = "10ª", Classroom = "aula 207", TeacherName = "Prof.Pinto" });

            // 12:30 - 2:00
            _scheduleSlots.Add(new ScheduleSlot { Id = 11, Day = "Lunes", TimeSlot = "12:30-2:00", Subject = "Informatica", Grade = "11ª", Classroom = "aula 201", TeacherName = "Prof.Gusman" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 12, Day = "Martes", TimeSlot = "12:30-2:00", Subject = "Ingles", Grade = "11ª", Classroom = "aula 208", TeacherName = "Prof.Sanchez" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 13, Day = "Miercoles", TimeSlot = "12:30-2:00", Subject = "Lenguaje", Grade = "11ª", Classroom = "aula 208", TeacherName = "Prof.Rios" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 14, Day = "Jueves", TimeSlot = "12:30-2:00", Subject = "Fisica", Grade = "11ª", Classroom = "aula 202", TeacherName = "Prof.Pinto" });
            _scheduleSlots.Add(new ScheduleSlot { Id = 15, Day = "Viernes", TimeSlot = "12:30-2:00", Subject = "Matematicas", Grade = "11ª", Classroom = "aula 308", TeacherName = "Prof.Morales" });

            // 5. Inicializar Votaciones
            _votingEvents.Add(new VotingEvent { Id = 1, Title = "Elección Representante Estudiantil 2026", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(2) });
            
            _votingCandidates.AddRange(new[]
            {
                new VotingCandidate { Id = 1, VotingEventId = 1, Name = "Camilo Torres", Proposal = "Mejorar las instalaciones deportivas", VotesCount = 45 },
                new VotingCandidate { Id = 2, VotingEventId = 1, Name = "Beatriz Gomez", Proposal = "Más talleres extracurriculares", VotesCount = 52 }
            });
        }

        // --- PROFESORES CRUD ---
        public List<Teacher> GetTeachers() => _teachers;
        public Teacher? GetTeacherById(int id) => _teachers.FirstOrDefault(t => t.Id == id);
        
        public Teacher AddTeacher(Teacher teacher)
        {
            teacher.Id = _teachers.Any() ? _teachers.Max(t => t.Id) + 1 : 1;
            // Asignar color dinámico basado en la posición
            string[] colors = { "#7E57C2", "#AB47BC", "#5C6BC0", "#26A69A", "#EC407A", "#26C6DA", "#FFA726", "#29B6F6" };
            teacher.BadgeColor = colors[teacher.Id % colors.Length];
            _teachers.Add(teacher);
            return teacher;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            var existing = GetTeacherById(teacher.Id);
            if (existing == null) return false;
            existing.Name = teacher.Name;
            existing.Subject = teacher.Subject;
            existing.Phone = teacher.Phone;
            
            // Actualizar nombre en los cursos donde enseña
            var affectedCourses = _courses.Where(c => c.TeacherId == teacher.Id);
            foreach (var course in affectedCourses)
            {
                course.TeacherName = teacher.Name;
            }
            return true;
        }

        public bool DeleteTeacher(int id)
        {
            var teacher = GetTeacherById(id);
            if (teacher == null) return false;
            
            // Desvincular de cursos
            var affectedCourses = _courses.Where(c => c.TeacherId == id);
            foreach (var course in affectedCourses)
            {
                course.TeacherId = 0;
                course.TeacherName = "Sin Profesor";
            }
            _teachers.Remove(teacher);
            return true;
        }

        // --- ESTUDIANTES CRUD ---
        public List<Student> GetStudents() => _students;
        public Student? GetStudentById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public Student AddStudent(Student student)
        {
            student.Id = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(student);
            return student;
        }

        public bool UpdateStudent(Student student)
        {
            var existing = GetStudentById(student.Id);
            if (existing == null) return false;
            existing.Name = student.Name;
            existing.Grade = student.Grade;
            existing.Status = student.Status;
            existing.Email = student.Email;
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student == null) return false;
            _students.Remove(student);
            return true;
        }

        // --- CURSOS CRUD ---
        public List<Course> GetCourses() => _courses;
        public Course? GetCourseById(int id) => _courses.FirstOrDefault(c => c.Id == id);

        public Course AddCourse(Course course)
        {
            course.Id = _courses.Any() ? _courses.Max(c => c.Id) + 1 : 1;
            var teacher = GetTeacherById(course.TeacherId);
            course.TeacherName = teacher != null ? teacher.Name : "Sin Profesor";
            _courses.Add(course);
            return course;
        }

        public bool UpdateCourse(Course course)
        {
            var existing = GetCourseById(course.Id);
            if (existing == null) return false;
            existing.Name = course.Name;
            existing.TeacherId = course.TeacherId;
            var teacher = GetTeacherById(course.TeacherId);
            existing.TeacherName = teacher != null ? teacher.Name : "Sin Profesor";
            existing.StudentsCount = course.StudentsCount;
            return true;
        }

        public bool DeleteCourse(int id)
        {
            var course = GetCourseById(id);
            if (course == null) return false;
            _courses.Remove(course);
            return true;
        }

        // --- HORARIOS ---
        public List<ScheduleSlot> GetScheduleSlots() => _scheduleSlots;
        
        public bool UpdateScheduleSlot(ScheduleSlot slot)
        {
            var existing = _scheduleSlots.FirstOrDefault(s => s.Id == slot.Id);
            if (existing == null) return false;
            existing.Subject = slot.Subject;
            existing.Grade = slot.Grade;
            existing.Classroom = slot.Classroom;
            existing.TeacherName = slot.TeacherName;
            return true;
        }

        // --- CONFIGURACIÓN ---
        public SystemSettings GetSettings() => _settings;
        
        public void UpdateSettings(SystemSettings newSettings)
        {
            _settings.SchoolName = newSettings.SchoolName;
            _settings.Address = newSettings.Address;
            _settings.Phone = newSettings.Phone;
            _settings.SchoolEmail = newSettings.SchoolEmail;
            
            _settings.AdminName = newSettings.AdminName;
            _settings.AdminEmail = newSettings.AdminEmail;
            if (!string.IsNullOrEmpty(newSettings.NewPassword))
            {
                _settings.CurrentPassword = new string('*', newSettings.NewPassword.Length);
            }
        }

        // --- VOTACIONES CRUD ---
        public List<VotingEvent> GetVotingEvents() => _votingEvents;
        public VotingEvent? GetVotingEventById(int id) => _votingEvents.FirstOrDefault(v => v.Id == id);
        
        public VotingEvent AddVotingEvent(VotingEvent vEvent)
        {
            vEvent.Id = _votingEvents.Any() ? _votingEvents.Max(v => v.Id) + 1 : 1;
            _votingEvents.Add(vEvent);
            return vEvent;
        }

        public bool DeleteVotingEvent(int id)
        {
            var vEvent = GetVotingEventById(id);
            if (vEvent == null) return false;
            _votingEvents.Remove(vEvent);
            // También eliminar candidatos asociados
            _votingCandidates.RemoveAll(c => c.VotingEventId == id);
            return true;
        }

        // --- CANDIDATOS CRUD ---
        public List<VotingCandidate> GetCandidatesByEventId(int eventId) => _votingCandidates.Where(c => c.VotingEventId == eventId).ToList();
        
        public VotingCandidate AddCandidate(VotingCandidate candidate)
        {
            candidate.Id = _votingCandidates.Any() ? _votingCandidates.Max(c => c.Id) + 1 : 1;
            _votingCandidates.Add(candidate);
            return candidate;
        }

        public bool DeleteCandidate(int id)
        {
            var candidate = _votingCandidates.FirstOrDefault(c => c.Id == id);
            if (candidate == null) return false;
            _votingCandidates.Remove(candidate);
            return true;
        }
    }
}
