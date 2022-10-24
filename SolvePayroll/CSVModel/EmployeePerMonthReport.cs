using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvePayroll.CSVModel
{
    public class EmployeePerMonthReport
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int Month{ get; set; }
        public int Year{ get; set; }
        public string JobType { get; set; }
        public double FeeDay { get; set; }
        public int FeeAllowance { get; set; }
        public int FeeDeduct { get; set; }
        public int FeeSite { get; set; }
        public int WordDays { get; set; }
        public double FullDays { get; set; }
        public double ExtraDays { get; set; }
        public double Salary { get; set; }
        public double AllowanceSalary { get; set; }
        public double ExtraSalary { get; set; }
        public double NetSalary { get; set; }
    }
}
