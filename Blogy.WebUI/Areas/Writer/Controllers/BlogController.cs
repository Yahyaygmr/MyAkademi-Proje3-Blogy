using Blogy.BusinessLayer.Abstaract;
using Blogy.BusinessLayer.ValidationRules.ArticleValidation;
using Blogy.EntityLayer.Concrete;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService, ICommentService commentService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public async Task<IActionResult> MyBlogList()
        {

            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            ViewBag.id = user.Name + " " + user.Surname;

            var values = _articleService.TGetArticlesByArticleByWriter(user.Id);

            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBlog()
        {
            
            ViewBag.categories = GetCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(Article article)
        {

            var validator = new CreateArticleValidator();
            var validationResult = validator.Validate(article);
            if (validationResult.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);

                article.AppUserId = user.Id;
                article.CreatedDate = DateTime.Now;

                _articleService.TInsert(article);

                return RedirectToAction("MyBlogList");
            }
            ViewBag.categories = GetCategories();
            return View();
               
        }
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("MyBlogList");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _articleService.TGetById(id);
            ViewBag.categories = GetCategories();

            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Article article)
        {
            var validator = new UpdateArticleValidator();
            var validationResult = validator.Validate(article);
            if (validationResult.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);

                article.AppUserId = user.Id;
                article.CreatedDate = DateTime.Now;

                _articleService.TUpdate(article);
                return RedirectToAction("MyBlogList");
            }
            ViewBag.categories = GetCategories();
            return View();
        }
        public IActionResult BlogComments(int id)
        {
            ViewBag.blogName = _articleService.TGetById(id).Title;

            var comments = _commentService.TGetCommentsByArticleId(id);
            return View(comments);
        }
        internal List<SelectListItem> GetCategories()
        {
            List<SelectListItem> categories = (from x in _categoryService.TGetListAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            return categories;
        }
    }
}
