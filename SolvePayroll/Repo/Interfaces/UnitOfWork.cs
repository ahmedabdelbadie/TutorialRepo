using SolvePayroll.APP_DATA;
using SolvePayroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAppTutorial.Repo;

namespace SolvePayroll.Repo.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private APPDBContext _context;
        private EmployeeRepository employeeRepository;
        private AttendanceRepository attendanceRepository;
        private EmployeeAttendanceRepository employeeAttendanceRepository;
        public UnitOfWork(APPDBContext context)
        {
            _context = context;
            //this.context = context;
            //Employee = new EmployeeRepository(this.context);
            //EmployeeAttendance = new EmployeeAttendanceRepository(this.context);
            //Attendance = new AttendanceRepository(this.context);
        }

        public IEmployee Employee
        {
            get
            {
                if (employeeRepository == null)
                {
                    return new EmployeeRepository(_context);
                }
                else { 
                    return employeeRepository;
                }
            }
        }

        public IAttendance Attendance
        {
            get
            {
                if (attendanceRepository == null)
                {
                    return new AttendanceRepository(_context);
                }
                else {
                    return attendanceRepository;
                }
            }
        }
        public IEmployeeAttendance EmployeeAttendance
        {
            get
            {
                if (employeeAttendanceRepository == null)
                {
                    return new EmployeeAttendanceRepository(_context);
                }
                else
                {
                    return employeeAttendanceRepository;
                }
            }
        }

        

        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
