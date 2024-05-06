using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class ContactUsController : Controller
    {
        private readonly IServiceManager _services;

        public ContactUsController(IServiceManager services)
        {
            _services = services;
        }
        [HttpGet]
        public IActionResult Index(int id = 1)
        {
            var contact = _services.ContactUsService.TGetById(id);

            return View(contact);
        }
        [HttpPost]
        public IActionResult Index(ContactUs contactUs)
        {
            _services.ContactUsService.TUpdate(contactUs);
            return View();
        }
    }
}
