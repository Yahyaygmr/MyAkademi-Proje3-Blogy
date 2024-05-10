using Blogy.BusinessLayer.Abstaract;
using Blogy.BusinessLayer.Concrete;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents.NavBarViewComponents
{
    public class _NavBarMessageComponentPartial : ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public _NavBarMessageComponentPartial(IServiceManager serviceManager, UserManager<AppUser> userManager)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _serviceManager.WriterMessageService.TGetWriterMessagesByUser(user);
            var get3message = values.OrderByDescending(x => x.WriterMessageId).Take(3).ToList();
            int isReadCount = values.Where(x => x.IsRead == false).Count();

            ViewBag.isReadCount = isReadCount;

            return View(get3message);
        }
    }
}
