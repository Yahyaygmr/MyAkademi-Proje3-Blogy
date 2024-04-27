using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogViewComponents
{
	public class _BlogListFooterComponentPartial : ViewComponent
	{
		private readonly IArticleService _articleService;

        public _BlogListFooterComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
		{
			var articles = _articleService.TGetLastNArticle(3);
			return View(articles);
		}
	}
}
