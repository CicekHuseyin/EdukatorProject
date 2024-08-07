﻿using Edukator.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edukator.BusinessLayer.Abstract
{
	public interface ICourseService : IGenericService<Course>
	{
		List<Course> TGetCoursesWithCategory();
		List<Course> TGetCoursesWithCategories();
        List<Course> TGetLast5Course();

    }
}
