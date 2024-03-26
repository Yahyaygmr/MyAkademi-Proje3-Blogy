using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogViewComponents
{
	public class _BlogListNavBarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
