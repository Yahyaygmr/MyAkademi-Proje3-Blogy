using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.ContactPageViewComponents
{
    public class _ContactAdressComponentPartial : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public _ContactAdressComponentPartial(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var contacts = _serviceManager.ContactUsService.TGetById(1);
            return View(contacts);
        }
    }
}
