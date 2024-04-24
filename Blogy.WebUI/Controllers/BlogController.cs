using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        public IActionResult BlogList()
        {
            return View();
        }
        public IActionResult BlogDetail(int id)
        {
            ViewBag.blogId = id;
            return View();
        }
    }
}
