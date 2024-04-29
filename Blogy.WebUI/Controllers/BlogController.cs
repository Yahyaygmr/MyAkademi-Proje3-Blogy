using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IServiceManager _manager;

        public BlogController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogList(string? filter)
        {
            var blogs = _manager.ArticleService.TArticleListWithFilter(filter);
            ViewBag.filter = filter;
            return View(blogs);
        }
        public IActionResult BlogDetail(int id)
        {
            ViewBag.blogId = id;
            return View();
        }
        public IActionResult LeaveAComment(int id, Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            comment.ArticleId = id;
            comment.Status = false;

            _manager.CommentService.TInsert(comment);

            return RedirectToAction("Index");
        }
    }
}
