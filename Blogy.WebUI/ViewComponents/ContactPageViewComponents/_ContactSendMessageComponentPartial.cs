using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.ContactPageViewComponents
{
    public class _ContactSendMessageComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
