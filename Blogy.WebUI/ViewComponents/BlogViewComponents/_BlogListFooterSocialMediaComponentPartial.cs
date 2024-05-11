using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogListFooterSocialMediaComponentPartial:ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public _BlogListFooterSocialMediaComponentPartial(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _serviceManager.SocialMediaService.TGetListAll();
            return View(values);
        }
    }
}
