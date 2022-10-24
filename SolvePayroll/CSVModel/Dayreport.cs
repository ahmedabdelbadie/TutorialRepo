using SolvePayroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvePayroll.CSVModel
{
    public class DayReport
    {
        public DateOnly DateOnly { get; set; }
        public double Day { get; set; }
        public double Extra { get; set; }
        public DayType DayType { get; set; }
        public double FeeDay { get; set; }
        public double FeeExtra { get; set; }

    }
}
