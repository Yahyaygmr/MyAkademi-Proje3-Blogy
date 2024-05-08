using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class NotificationController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public NotificationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var notifications = _serviceManager.NotificationService.TGetListAll();
            var values = notifications.OrderByDescending(x=>x.NotificationId).ToList();
            return View(values);
        }
    }
}
