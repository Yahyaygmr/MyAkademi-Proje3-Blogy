using Blogy.BusinessLayer.Abstaract;
using Blogy.BusinessLayer.Concrete;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class MessageController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IServiceManager serviceManager, UserManager<AppUser> userManager)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user =await _userManager.FindByNameAsync(User.Identity.Name);

            var messages = _serviceManager.WriterMessageService.TGetWriterMessagesByUser(user);

            return View(messages);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            ViewBag.emails = GetUserMails();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            message.AppUserId = user.Id;
            message.SendDate = DateTime.Now;
            message.Status = true;
            message.IsRead = false;

            _serviceManager.WriterMessageService.TInsert(message);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteMessage(int id)
        {
            _serviceManager.WriterMessageService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult WriterMessageDetail(int id)
        {
            var message = _serviceManager.WriterMessageService.TGetWriterMessagesByIdWithUser(id);
            return View(message);
        }
        public IActionResult MessageControl(int id)
        {
            var message = _serviceManager.WriterMessageService.TGetById(id);
            if(message.IsRead)
            {
                return RedirectToAction("WriterMessageDetail", new { id = message.WriterMessageId });
            }
            else
            {
                message.IsRead =true;
                _serviceManager.WriterMessageService.TUpdate(message);
                return RedirectToAction("WriterMessageDetail", new {id = message.WriterMessageId});
            }
        }
        public List<SelectListItem> GetUserMails()
        {
            List<string> userMails = new List<string>();

            var values = _userManager.Users.ToList();
            foreach (var user in values)
            {
                userMails.Add(user.Email);
            }
            List<SelectListItem> mails = (from x in userMails
                                          select new SelectListItem
                                          {
                                              Text = x.ToString(),
                                              Value = x.ToString()
                                          }).ToList();

            return mails;
        }
    }

}
