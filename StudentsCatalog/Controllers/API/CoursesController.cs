using StudentsCatalog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            return _DbContext.Courses.ToList();
        }
        public Course GetCourse(int Id)
        {
            var course = _DbContext.Courses.SingleOrDefault(c => c.CourseID == Id);
            if (course == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else

                return course;
        }
        //Post/courses
        [HttpPost]
        //PostCourse for example is better not to have http post 
        public Course CreateCourse(Course course)
        {
            //Validate the model first 
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            else
            {
                _DbContext.Courses.Add(course);
                _DbContext.SaveChanges();
                return course;
            }
        }
        // put api/customers/1 // update 
        [HttpPut]
        public void UpdateCourse(int id, Course course)
        { //Validate the model first 
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            else
            {
                var courseDb = _DbContext.Courses.SingleOrDefault(c => c.CourseID == id);
                if (courseDb == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                else
                {
                    courseDb.Title = course.Title;
                    _DbContext.SaveChanges();
                }
;            }
        }
        //api/course/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var courseDb = _DbContext.Courses.SingleOrDefault(c => c.CourseID == id);
            if (courseDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
            {
                _DbContext.Courses.Remove(courseDb);
                _DbContext.SaveChanges();
            }
        }

    }
}
