using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents.NavBarViewComponents
{
    public class _NavBarNotificationComponentPartial : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public _NavBarNotificationComponentPartial(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            
            var allValues = _serviceManager.NotificationService.TGetListAll();
            int count = allValues.Where(x=>x.CreatedDate.ToShortDateString() ==  DateTime.Now.ToShortDateString()).Count();
            ViewBag.count = count.ToString();

            var values = _serviceManager.NotificationService.TGetLast3Notifications();
            return View(values);
        }
    }
}
