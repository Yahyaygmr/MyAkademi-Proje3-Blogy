using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class BlogController : Controller
    {
        private readonly IServiceManager _services;
        public BlogController(IServiceManager services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            var blogs = _services.ArticleService.TGetArticleWithWriterAndCategory();
            return View(blogs);
        }
    }
}
