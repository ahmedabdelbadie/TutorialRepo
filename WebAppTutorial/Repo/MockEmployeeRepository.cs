using WebAppTutorial.Models;
using WebAppTutorial.ViewsModel;

namespace WebAppTutorial.Repo
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employeeRepository;
        public MockEmployeeRepository()
        {
            _employeeRepository = new List<Employee>()
            {
                new Employee(){ Id = 1 , Name= "Ahmed",Email= "Ahmed@mail.com" , Department = Dep.HR},
                new Employee(){ Id = 2 , Name= "Mohamed",Email= "Mohamed@mail.com" , Department = Dep.Financial},
                new Employee(){ Id = 3 , Name= "Yosef",Email= "Yosef@mail.com" , Department = Dep.Selling}
            };
        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeRepository.Max(x => x.Id) + 1;
            _employeeRepository.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee? employee = _employeeRepository.FirstOrDefault(emp => emp.Id == id);
            if(employee != null)
            {
                _employeeRepository.Remove(employee);
            }
            return employee;
        }

        public int GetCount()
        {
            return _employeeRepository.Count;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.ToList();
        }

        public Employee Update(HomeEditEmployee employeeChanges, int Id)
        {
            Employee? employee = _employeeRepository.FirstOrDefault(emp => emp.Id == Id);
            if(employee != null)
            {
                employee.Email = employeeChanges.Email;
                employee.Name = employeeChanges.Name;
                employee.Department = employeeChanges.Department;

            }
            return employee;
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
