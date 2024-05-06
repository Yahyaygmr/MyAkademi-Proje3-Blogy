using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class HelpAdminController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HelpAdminController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var requests = _serviceManager.HelpAdminService.TGetHelpAdminWithAppUser();
            return View(requests);
        }
        public IActionResult HelpRequestDetail(int id)
        {
            var request = _serviceManager.HelpAdminService.TGetHelpAdminWithAppUserById(id);
            return View(request);
        }
        public IActionResult MarkAsSolved(int id)
        {
            var request = _serviceManager.HelpAdminService.TGetById(id);

            if(!request.Status)
            {
                request.Status = true;
                _serviceManager.HelpAdminService.TUpdate(request);
            }
            return RedirectToAction("Index");
        }

    }
}
