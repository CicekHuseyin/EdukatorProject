using Edukator.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edukator.PresentationLayer.Controllers
{
	public class StatisticController : Controller
	{
		public IActionResult Index()
		{
			Context context = new Context();
			ViewBag.totalCategory = context.Categories.Count();
			ViewBag.totalCourse = context.Courses.Count();
			ViewBag.totalPrice = context.Courses.Sum(x => x.Price);
			ViewBag.getCsharpCoursePrice = context.Courses.Where(x => x.Title == "C# Eğitimi").Select(y => y.Price).FirstOrDefault();

			ViewBag.avgReview = context.Courses.Average(x => x.Review);
			ViewBag.getOverThen30Price = context.Courses.Where(x => x.Price > 30).Count();
			ViewBag.lastCoursePrice = context.Courses.Where(x => x.CourseID == 6).Select(y => y.Price).FirstOrDefault();
			ViewBag.getTitleByCourseId1 = context.Courses.Where(x => x.CategoryID == 1).Select(y => y.Title).FirstOrDefault();

			ViewBag.softwareCourseCount = context.Courses.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Yazılım").Select(z => z.CategoryID)).FirstOrDefault()).Count();
			ViewBag.maxCoursePrice = context.Courses.Max(x => x.Price);
			ViewBag.minCoursePrice = context.Courses.Min(x => x.Price);
			ViewBag.mostExpensiveCourse = context.Courses.Where(x => x.Price == (context.Courses.Max(y => y.Price))).Select(z => z.Title).FirstOrDefault();

			ViewBag.lastCourseTitle = context.Courses.Where(x => x.CourseID == (context.Courses.Max(y => y.CourseID))).Select(z => z.Title).FirstOrDefault();
			ViewBag.avgPriceSoftwareCourse = context.Courses.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Yazılım").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.Price);
			ViewBag.last3CourseTotalPrice = context.Courses.OrderByDescending(x => x.CourseID).Take(3).Sum(y => y.Price);
			ViewBag.getCourseCategorySoftwareAndReviewMore95core = context.Courses.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Yazılım").Select(z => z.CategoryID)).FirstOrDefault() && x.Review >= 9).Select(w => w.Title).FirstOrDefault();
			return View();
		}
	}
}

