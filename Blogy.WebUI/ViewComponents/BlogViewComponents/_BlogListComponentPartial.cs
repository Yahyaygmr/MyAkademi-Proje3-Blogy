using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogListComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _BlogListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetArticleWithWriter();
            return View(values);
        }
    }
}
