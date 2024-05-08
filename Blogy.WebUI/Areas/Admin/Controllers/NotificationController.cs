using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
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
            return View(notifications);
        }
        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNotification(Notification notification)
        {
            notification.CreatedDate = DateTime.Now;
            notification.Status = true;
            _serviceManager.NotificationService.TInsert(notification);

            return RedirectToAction("Index");
        }
    }
}
