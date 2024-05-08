using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class MessageController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public MessageController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var values = _serviceManager.MessageService.TGetListAll();
            return View(values);
        }
        public IActionResult MessageDetail(int id)
        {
            var message = _serviceManager.MessageService.TGetById(id);

            return View(message);
        }
    }
}
