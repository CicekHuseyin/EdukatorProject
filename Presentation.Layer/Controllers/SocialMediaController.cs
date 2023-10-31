using Edukator.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edukator.PresentationLayer.Controllers
{
	public class SocialMediaController : Controller
	{
		private readonly ISocialMediaService _socialMediaService;

		public SocialMediaController(ISocialMediaService socialMediaService)
		{
			_socialMediaService = socialMediaService;
		}

		public IActionResult Index()
		{
			var values = _socialMediaService.TGetList();
			return View(values);
		}
	}
}
