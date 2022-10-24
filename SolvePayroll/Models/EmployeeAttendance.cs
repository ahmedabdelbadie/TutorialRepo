using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvePayroll.Models
{
    public class EmployeeAttendance
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttendanceId { get; set; }
        public Attendance Attendance { get; set; }


        public double WorkingHourPerDay { get; set; }




    }
}
