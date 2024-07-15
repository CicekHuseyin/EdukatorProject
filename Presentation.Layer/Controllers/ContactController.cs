using Edukator.BusinessLayer.Abstract;
using Edukator.EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Edukator.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddMessage(Contact contact)
        {
            _contactService.TInsert(contact);
            return RedirectToAction("Index");
        }
    }
}
