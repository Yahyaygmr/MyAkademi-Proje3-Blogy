using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Areas.Admin.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class RolesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RolesController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.Select(x=> new GetRolesViewModel
            {
                RoleId = x.Id,
                RoleName = x.Name,
            }).ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel roleModel)
        {
            var result = await _roleManager.CreateAsync(
                new AppRole()
                {
                    Name = roleModel.Name,
                    Description = roleModel.Description
                });
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateRole(UpdateRoleViewModel roleModel)
        {
            return View();
        }
        public IActionResult DeleteRole(int id)
        {
            return View();
        }
    }
}
