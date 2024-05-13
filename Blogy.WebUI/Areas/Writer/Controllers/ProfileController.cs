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
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            UpdateWriterProfileViewModel model = new UpdateWriterProfileViewModel()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                UserName = user.UserName,
            };


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UpdateWriterProfileViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if(!(string.IsNullOrEmpty(model.Password)))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            }
            user.ImageUrl = model.ImageUrl;

            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("LogOut", "Login");
            }
            return View(model);
        }
    }
}
