using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Areas.Admin.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
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
            var roles = _roleManager.Roles.Select(x => new GetRolesViewModel
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
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            return View(new UpdateRoleViewModel() { RoleId = role.Id, Name = role.Name, Description = role.Description });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel roleModel)
        {
            var role = await _roleManager.FindByIdAsync(roleModel.RoleId.ToString());

            role.Name = roleModel.Name;
            role.Description = roleModel.Description;

            await _roleManager.UpdateAsync(role);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteRoleAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

           await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }
        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public async Task<ActionResult> AssingRoleToUser(int id)
        {
            ViewBag.userId = id;
            var currentUser = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(currentUser);
            var roleViewModelList = new List<AssignRoleToUserViewModel>();
            foreach (var role in roles)
            {
                var assignRoleToUserViewModel = new AssignRoleToUserViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };
                if (userRoles.Contains(role.Name))
                {
                    assignRoleToUserViewModel.Exist = true;
                }
                roleViewModelList.Add(assignRoleToUserViewModel);
            }
            return View(roleViewModelList);
        }
        [HttpPost]
        public async Task<ActionResult> AssingRoleToUser(int userId,List<AssignRoleToUserViewModel> requestList)
        {
            var userToAssignRole = await _userManager.FindByIdAsync(userId.ToString());

            foreach (var role in requestList)
            {
                if(role.Exist)
                {
                    await _userManager.AddToRoleAsync(userToAssignRole, role.RoleName);

                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(userToAssignRole, role.RoleName);
                }
            }

            return RedirectToAction("UserList");
        }
    }
}
