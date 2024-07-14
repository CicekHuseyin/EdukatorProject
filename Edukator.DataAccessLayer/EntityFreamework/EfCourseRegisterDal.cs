using Edukator.DataAccessLayer.Abstract;
using Edukator.DataAccessLayer.Concrete;
using Edukator.DataAccessLayer.Repositories;
using Edukator.EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edukator.DataAccessLayer.EntityFreamework
{
    public class EfCourseRegisterDal : GenericRepository<CourseRegister>, ICourseRegisterDal
    {
        public List<CourseRegister> CourseRegisterListWithCoursByUser(int id)
        {
            using var context = new Context();
            var values = context.CourseRegisters.Where(x => x.AppUSerID == id).Include(y => y.Course).ToList();
            return values; 
        }

        public List<CourseRegister> CourseRegisterListWithCoursesAndUsers()
        {
            using var context = new Context();
            var values = context.CourseRegisters.Include(x => x.Course).Include(y => y.AppUser).ToList();
            return values;
        }
    }
}
