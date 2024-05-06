using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class AboutUsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AboutUsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult Index(int id = 1)
        {
            About values = _serviceManager.AboutService.TGetById(id);

            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            _serviceManager.AboutService.TUpdate(about);

            return View();
        }
    }
}
