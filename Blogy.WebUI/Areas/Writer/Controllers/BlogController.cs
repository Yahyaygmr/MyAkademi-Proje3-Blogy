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
        private readonly IServiceManager _serviceManager;

        public BlogController(UserManager<AppUser> userManager, IServiceManager serviceManager)
        {
            _userManager = userManager;
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> MyBlogList()
        {

            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            ViewBag.id = user.Name + " " + user.Surname;

            var values = _serviceManager.ArticleService.TGetArticlesByArticleByWriter(user.Id);

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

                _serviceManager.ArticleService.TInsert(article);

                return RedirectToAction("MyBlogList");
            }
            ViewBag.categories = GetCategories();
            return View();
               
        }
        public IActionResult DeleteBlog(int id)
        {
            _serviceManager.ArticleService.TDelete(id);
            return RedirectToAction("MyBlogList");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _serviceManager.ArticleService.TGetById(id);
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

                _serviceManager.ArticleService.TUpdate(article);
                return RedirectToAction("MyBlogList");
            }
            ViewBag.categories = GetCategories();
            return View();
        }
        public IActionResult BlogComments(int id)
        {
            ViewBag.blogName = _serviceManager.ArticleService.TGetById(id).Title;

            var comments = _serviceManager.CommentService.TGetCommentsByArticleId(id);
            return View(comments);
        }
        internal List<SelectListItem> GetCategories()
        {
            List<SelectListItem> categories = (from x in _serviceManager.CategoryService.TGetListAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            return categories;
        }
    }
}
