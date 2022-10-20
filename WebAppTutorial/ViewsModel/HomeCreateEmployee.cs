using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WebAppTutorial.Models;

namespace WebAppTutorial.ViewsModel
{
    public class HomeCreateEmployee
    {

        [Required]
        [StringLength(20, ErrorMessage = "The ThumbnailPhotoFileName value cannot exceed 20 characters. ")]
        public string Name { get; set; }
        [Required]
        //[RegularExpression(pattern: @"[a-z0-9]+@[a-z]+\.[a-z]{2,3}")]
        public string Email { set; get; }

        [Required]
        public Dep Department { set; get; }

        public IFormFile? Photo { set; get; }
        public static Employee MapCreateEmployee(HomeCreateEmployee createEmployee,string photoName)
        {
            return new Employee()
            {
                Name = createEmployee.Name,
                Department = createEmployee.Department,
                Email = createEmployee.Email,
                photoPath = photoName,
            };

        }
    }

}
