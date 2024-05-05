using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
