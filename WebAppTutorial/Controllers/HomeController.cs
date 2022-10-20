using Microsoft.AspNetCore.Mvc;
using WebAppTutorial.Models;
using WebAppTutorial.Repo;
using WebAppTutorial.ViewsModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace WebAppTutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IWebHostEnvironment _hostingEnv;

        public HomeController(IEmployeeRepository employeeRepository,IWebHostEnvironment hostingEnvironment)
        {
            _employeeRepo = employeeRepository;
            _hostingEnv = hostingEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee>? employees = _employeeRepo.GetEmployees();
            HomeEmployeesViewModel homeEmployeesViewModel = new HomeEmployeesViewModel() { PageTitle = "Employees from index", Employees = employees };
            return View(homeEmployeesViewModel);
        }
        public IActionResult Details(int? id)
        {
            Employee employee = _employeeRepo.GetEmployee(id ?? 1);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }
            HomeEmployeesViewModel homeEmployeeViewModel = new HomeEmployeesViewModel() { PageTitle = "Employee Details", Employees = new List<Employee>() { employee } };
            return View(homeEmployeeViewModel);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(HomeCreateEmployee newEmployee)
        {
            if (ModelState.IsValid)
            {
                string photoName = ProccesUniquePhoteName(newEmployee);
               
                var emp = _employeeRepo.Add(HomeCreateEmployee.MapCreateEmployee(newEmployee, photoName));
                return RedirectToAction("Details", new { id = emp.Id });
            }
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            Employee employee = _employeeRepo.GetEmployee(id);
            HomeEditEmployee homeEditEmployee = new HomeEditEmployee()
            {
                Department = employee.Department,
                Name = employee.Name,
                Email = employee.Email,
                ExistingPhotoPath = employee.photoPath,
                Id = id
            };

            return View(homeEditEmployee);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(HomeEditEmployee homeEditEmployee)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepo.GetEmployee(homeEditEmployee.Id);
                string photoName = null;
                if (homeEditEmployee != null)
                {
                    if(homeEditEmployee.ExistingPhotoPath != null)
                    {
                       string filepath= Path.Combine(_hostingEnv.WebRootPath, "images",homeEditEmployee.ExistingPhotoPath);
                        System.IO.File.Delete(filepath); 
                    }
                     photoName = ProccesUniquePhoteName(homeEditEmployee);
                }
                
                employee = HomeEditEmployee.MapEditEmployee(homeEditEmployee,employee, photoName);
                var emp = _employeeRepo.Update(employee);
                return RedirectToAction("Details", new { id = emp.Id });
            }
            return View(homeEditEmployee);
        }

        private string ProccesUniquePhoteName(HomeCreateEmployee newEmp)
        {
            string photoName = null;
            if (newEmp.Photo != null)
            {
                var imagePath = Path.Combine(_hostingEnv.WebRootPath, "images");
                photoName = Guid.NewGuid().ToString() + "_" + newEmp.Photo.FileName;
                string filePath = Path.Combine(imagePath, photoName);
                using(var fileStream= new FileStream(filePath, FileMode.Create))
                {
                    newEmp.Photo.CopyTo(fileStream);
                }

            }

            return photoName;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            _employeeRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
