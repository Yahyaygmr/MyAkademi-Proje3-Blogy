using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailGetOtherBlogPostsByWriterComponentPartial : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public _BlogDetailGetOtherBlogPostsByWriterComponentPartial(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke(int id)
        {
            var user = _serviceManager.ArticleService.TGetWriterInfoByArticleWriter(id);

            var articles = _serviceManager.ArticleService
                .TGetArticlesByArticleByWriter(user.Id)
                .Take(3).ToList();
            return View(articles);
        }
    }
}
