﻿using Edukator.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Edukator.PresentationLayer.ViewComponents.Dashboard
{
    public class _DashboardLast4MessagePartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _DashboardLast4MessagePartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.TGetLast4Message();
            return View(values);
        }
    }
}
