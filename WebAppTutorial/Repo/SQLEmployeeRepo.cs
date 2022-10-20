using WebAppTutorial.Data;
using WebAppTutorial.Models;

namespace WebAppTutorial.Repo
{
    public class SQLEmployeeRepo : IEmployeeRepository
    {
        public readonly AppDBContext _dbContext;
        public SQLEmployeeRepo(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public Employee Add(Employee newEmployee)
        {
            _dbContext.employees.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            var employee = _dbContext.employees.Find(id);
            if (employee == null)
            {
                _dbContext.employees.Remove(employee);
                _dbContext.SaveChanges();

            }
            return employee;

        }

        public int GetCount()
        {
            return _dbContext.employees.Count();
        }

        public Employee GetEmployee(int id)
        {
            return _dbContext.employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _dbContext.employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _dbContext.employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return employeeChanges;
        }
    }
}
