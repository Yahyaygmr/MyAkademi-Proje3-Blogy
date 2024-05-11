using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class SocialMediaController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public SocialMediaController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var values = _serviceManager.SocialMediaService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddNewAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewAccount(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            _serviceManager.SocialMediaService.TInsert(socialMedia);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditAccount(int id)
        {
            var value = _serviceManager.SocialMediaService.TGetById(id);

            return View(value);
        }
        [HttpPost]
        public IActionResult EditAccount(SocialMedia socialMedia)
        {
            _serviceManager.SocialMediaService.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAccount(int id)
        {
            _serviceManager.SocialMediaService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
