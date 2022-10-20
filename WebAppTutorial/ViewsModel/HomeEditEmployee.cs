using System.ComponentModel.DataAnnotations;
using WebAppTutorial.Models;

namespace WebAppTutorial.ViewsModel
{
    public class HomeEditEmployee : HomeCreateEmployee
    {
        public int Id { get; set; }
        

        public string? ExistingPhotoPath { set; get; }

        public static Employee MapEditEmployee(HomeEditEmployee EditEmployee,Employee employee, string photoName)
        {
            employee.Name = EditEmployee.Name;
            employee.Department = EditEmployee.Department;
            employee.Email = EditEmployee.Email;
            employee.photoPath = photoName;
            return employee;

        }
    }
}
