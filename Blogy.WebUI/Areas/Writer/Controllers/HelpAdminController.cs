using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class HelpAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
