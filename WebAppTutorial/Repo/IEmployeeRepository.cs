using WebAppTutorial.Models;

namespace WebAppTutorial.Repo
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        Employee Delete(int id);
        Employee Update(Employee employee);
        IEnumerable<Employee> GetEmployees();
        Employee Add(Employee newEmployee);
        int GetCount();
    }
}
