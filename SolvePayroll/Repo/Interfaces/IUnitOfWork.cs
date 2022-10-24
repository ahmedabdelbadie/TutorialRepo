using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvePayroll.Repo.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployee Employee
        {
            get;
        }
        public IEmployeeAttendance EmployeeAttendance
        {
            get;
        }
        public IAttendance Attendance
        {
            get;
        }
        int Save();
    }
}
