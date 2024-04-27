using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailOtherPostsComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _BlogDetailOtherPostsComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var articles = _articleService.TGetLastNArticle(4);
            return View(articles);
        }
    }
}
