using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogViewComponents
{
	public class _BlogListScriptsComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
