using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailTagsComponentDetail : ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
