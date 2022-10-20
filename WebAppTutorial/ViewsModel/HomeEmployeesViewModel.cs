using WebAppTutorial.Models;

namespace WebAppTutorial.ViewsModel
{
    public class HomeEmployeesViewModel
    {
        public string PageTitle { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
