using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Areas.Admin.Models.UserList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class AdminWriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminWriterController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userList = _userManager.Users.OrderByDescending(x=>x.Id).ToList();

            List<UserListWithRoles> usersWithRoles = new List<UserListWithRoles>();
            foreach (var user in userList)
            {
                var roles =await _userManager.GetRolesAsync(user);
                usersWithRoles.Add(new UserListWithRoles
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    EmailConfirmed = user.EmailConfirmed,
                    ImageUrl = user.ImageUrl,
                    Roles = roles.ToList()
                });
            }
            return View(usersWithRoles);
        }
    }
}
