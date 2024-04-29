using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavBarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _LayoutNavBarComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.userName = user.Name + " " + user.Surname.ToUpper();
            ViewBag.image = user.ImageUrl;
            return View();
        }
    }
}
