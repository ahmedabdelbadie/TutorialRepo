using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvePayroll.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        
        public string Name { get; set; }

        public double FeeDay { get; set; }
        public double FeeAllowance { get; set; }
        public double FeeDeduct { get; set; }
        public double FeeSite { get; set; }
        public double FeeDifferentiate { get; set; }
        public string JobType { get; set; }
        public ICollection<EmployeeAttendance> EmployeeAttendance { get; set; }


    }
}
