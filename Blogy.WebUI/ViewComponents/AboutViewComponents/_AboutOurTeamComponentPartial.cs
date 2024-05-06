using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutOurTeamComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AboutOurTeamComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userList = _userManager.Users.ToList();
            return View(userList);
        }
    }
}
