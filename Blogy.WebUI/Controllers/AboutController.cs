using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{
        public IActionResult Index()
		{
			return View();
		}
	}
}
