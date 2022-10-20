using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebAppTutorial.Controllers
{
    public class Error : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HTTPStatusCodeHandler(int statusCode)
        {
            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMSG = "Sorry the resource cann't be found";
                    break;
            }
            return View();
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult ErrorDefault()
        {
            IExceptionHandlerPathFeature? exceptionDetail = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.path = exceptionDetail.Path;
            return View("Error");
        }
    }
}
