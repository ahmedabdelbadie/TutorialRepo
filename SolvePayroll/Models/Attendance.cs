using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvePayroll.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttendanceId  { get; set; }
        public DateOnly DateOnly { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DayType DayType { get; set; }

        public ICollection<EmployeeAttendance> EmployeeAttendance { get; set; }
    }
    public enum DayType
    {
        FullDay,
        HalfDay,
        Leave,
        vacation,
        Rest
    }
}
