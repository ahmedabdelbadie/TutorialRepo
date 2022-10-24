using SolvePayroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvePayroll.Repo.Interfaces
{
    public interface IAttendance : IGenericRepository<Attendance> { }
    public interface IEmployee : IGenericRepository<Employee> { }
    public interface IEmployeeAttendance : IGenericRepository<EmployeeAttendance> { }

}
