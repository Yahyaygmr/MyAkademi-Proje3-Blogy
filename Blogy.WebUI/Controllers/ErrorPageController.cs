using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult Page403()
        {
            return View();
        }
        public IActionResult Page404()
        {
            return View();
        }
    }
}
