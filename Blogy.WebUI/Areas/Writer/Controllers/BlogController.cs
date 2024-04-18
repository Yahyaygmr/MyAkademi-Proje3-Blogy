using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
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
            List<SelectListItem> categories = (from x in _categoryService.TGetListAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(Article article)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);

            article.AppUserId = user.Id;
            article.WriterId = 1;
            article.CreatedDate = DateTime.Now;

            _articleService.TInsert(article);

            return RedirectToAction("MyBlogList");
        }
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("MyBlogList");
        }
    }
}
