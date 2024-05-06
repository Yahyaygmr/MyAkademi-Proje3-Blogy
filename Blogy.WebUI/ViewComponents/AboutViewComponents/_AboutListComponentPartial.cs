using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutListComponentPartial:ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public _AboutListComponentPartial(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var about = _serviceManager.AboutService.TGetById(1);

            return View(about);
        }
    }
}
