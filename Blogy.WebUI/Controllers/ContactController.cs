using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		private readonly IServiceManager _serviceManager;

		public ContactController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SendMessage(Message message)
		{
			message.IsRead = false;
			_serviceManager.MessageService.TInsert(message);

			return RedirectToAction("Index");
		}
	}
}
