using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class StatisticController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public StatisticController(IServiceManager serviceManager, UserManager<AppUser> userManager)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<GoogleChartViewModel> chartViewModel = new List<GoogleChartViewModel>();
            var categories = _serviceManager.CategoryService.TGetListAll();
            foreach (var category in categories)
            {
                var count = _serviceManager.ArticleService.GetTContext().Where(x=> x.CategoryId == category.CategoryId).Count();
                chartViewModel.Add(new GoogleChartViewModel
                {
                    BlogCount = count,
                    CategoryName = category.Name,
                });
            }

            #region Statistics
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            int myBlogsCount = _serviceManager.ArticleService.TGetArticlesByArticleByWriter(user.Id).Count();
            Article? myLastBlog = _serviceManager.ArticleService.TGetArticlesByArticleByWriter(user.Id)?
                .FirstOrDefault();
            string? myLastBlogDate = myLastBlog?.CreatedDate.ToString("dd MMM yyyy");
            string? myLastBlogName = myLastBlog?.Title;
            int blogCount = _serviceManager.ArticleService.GetTContext().Count();
            int commentCount = _serviceManager.CommentService.TGetListAll().Count;
            string? mostUsedCategoy = _serviceManager.CategoryService
                .GetTContext()
                .OrderByDescending(c => c.Articles.Count)
                .FirstOrDefault()?
                .Name;
            string? lastCreatedCategory = _serviceManager.CategoryService
                .GetTContext().OrderByDescending(c => c.CategoryId)
                .First().Name;
            int writerCount = _userManager.Users.Count();
            int notificationCount = _serviceManager.NotificationService.GetTContext().Count();
            string? lastNotification = _serviceManager.NotificationService
                .GetTContext()
                .OrderByDescending(c => c.NotificationId)
                .First()
                .Content;

            ViewBag.myBlogsCount = myBlogsCount;
            ViewBag.commentCount = commentCount;
            ViewBag.blogCount = blogCount;
            ViewBag.myLastBlogName = myLastBlogName;
            ViewBag.myLastBlogDate = myLastBlogDate;
            ViewBag.mostUsedCategoy = mostUsedCategoy;
            ViewBag.lastCreatedCategory = lastCreatedCategory;
            ViewBag.writerCount = writerCount;
            ViewBag.notificationCount = notificationCount;
            ViewBag.lastNotification = lastNotification;

            #endregion


            return View(chartViewModel);
        }
    }
}
