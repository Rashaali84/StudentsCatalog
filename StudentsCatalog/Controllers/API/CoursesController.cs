using StudentsCatalog.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace StudentsCatalog.Controllers.API
{
    public class CoursesController : ApiController
    {
        // api controlller
        private StudentsEntities _DbContext;
        public CoursesController()
        {
            _DbContext = new StudentsEntities();





        }
        //Get//Courses
        [HttpGet]
        public IEnumerable<Course> GetCourses()
        {

        }
    }
}
