using Blogy.BusinessLayer.Abstaract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ICategoryService _categoryService;

        public StatisticController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.categoryCount = _categoryService.TGetCategoryCount();
            return View();
        }
    }
}
