using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public AboutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
		{
			var userList = _userManager.Users.ToList();
			return View(userList);
		}
	}
}
