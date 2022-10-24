using SolvePayroll.APP_DATA;
using SolvePayroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SolvePayroll.Repo.Interfaces
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployee
    {
        public EmployeeRepository(APPDBContext context) : base(context) { }
    }
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendance
    {
        public AttendanceRepository(APPDBContext context) : base(context) { }
    }
    public class EmployeeAttendanceRepository : GenericRepository<EmployeeAttendance>, IEmployeeAttendance
    {
        public EmployeeAttendanceRepository(APPDBContext context) : base(context) { }
    }
}
