using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppTutorial.Validation;

namespace WebAppTutorial.ViewsModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "isEmailUse", controller: "Account")]
        [CustomEmailDomainValidation(allowDomain:"Badea.com",ErrorMessage ="The domain doesn't allowed")]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
    }
}
