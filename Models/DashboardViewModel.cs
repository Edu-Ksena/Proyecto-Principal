using System.Collections.Generic;

namespace mi_proyecto.Models
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; } = 1400;
        public int TotalTeachers { get; set; } = 32;
        public int ActiveCoursesCount { get; set; } = 18;
        public int ActiveSchedulesCount { get; set; } = 18;
        public List<ScheduleSlot> TodayClasses { get; set; } = new List<ScheduleSlot>();
    }
}
