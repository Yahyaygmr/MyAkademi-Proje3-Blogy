using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
		{
			return View();
		}
		public IActionResult BlogList()
        {
            var blogs = _articleService.TGetArticleWithWriterAndCategory();
            return View(blogs);
        }
        public IActionResult BlogDetail(int id)
        {
            ViewBag.blogId = id;
            return View();
        }
    }
}
