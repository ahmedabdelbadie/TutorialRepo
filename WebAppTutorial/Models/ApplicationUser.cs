using Microsoft.AspNetCore.Identity;

namespace WebAppTutorial.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string city { set; get; }
    }
}
