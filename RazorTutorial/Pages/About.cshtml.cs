using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTutorial.Pages
{
    public class AboutModel : PageModel
    {
        public AboutModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string ReturnUrl { get; set; }
        public IConfiguration Configuration { get; }

        public void OnGet()
        {
            ReturnUrl = "retrun ahmed url";
        }
    }
}
