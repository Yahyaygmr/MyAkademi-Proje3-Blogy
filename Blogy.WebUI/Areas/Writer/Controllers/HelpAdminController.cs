using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class HelpAdminController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;
        public HelpAdminController(IServiceManager serviceManager, UserManager<AppUser> userManager)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var requests = _serviceManager.HelpAdminService.TGetHelpAdminByUser(user.Id);
            return View(requests);
        }
        [HttpGet]
        public IActionResult CreateHelpRequest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateHelpRequest(HelpAdmin helpAdmin)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            helpAdmin.AppUserId = user.Id;
            helpAdmin.Status = false;

            _serviceManager.HelpAdminService.TInsert(helpAdmin);

            return RedirectToAction("Index");
        }
        public IActionResult HelpRequestDetail(int id)
        {
            var requests = _serviceManager.HelpAdminService.TGetById(id);
            return View(requests);
        }
        public IActionResult DeleteHelpRequest(int id)
        {
            _serviceManager.HelpAdminService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
