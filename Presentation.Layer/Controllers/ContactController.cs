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
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactService.TInsert(contact);
            return RedirectToAction("Index");
        }
    }
}
