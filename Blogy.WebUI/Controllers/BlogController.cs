using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public BlogController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogList(string? filter)
        {
            var blogs = _articleService.TArticleListWithFilter(filter);
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

            _commentService.TInsert(comment);

            return RedirectToAction("Index");
        }
    }
}
