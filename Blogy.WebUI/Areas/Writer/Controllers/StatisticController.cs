using Blogy.BusinessLayer.Abstaract;
using Blogy.WebUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class StatisticController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public StatisticController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
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
            return View(chartViewModel);
        }
    }
}
