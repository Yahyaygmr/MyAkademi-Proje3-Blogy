using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.ContactPageViewComponents
{
    public class _ContactAdressComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
