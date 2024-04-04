using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailByCoverInfoComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

		public _BlogDetailByCoverInfoComponentPartial(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public IViewComponentResult Invoke(int id)
        {
            var value = _articleService.TGetById(id);
            return View(value);
        }
    }
}
