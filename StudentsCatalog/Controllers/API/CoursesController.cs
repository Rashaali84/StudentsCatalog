using StudentsCatalog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using StudentsCatalog.Dtos;
using AutoMapper;

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
        //instal automapper from nuget pacjage manager to map objects to dtos 
        //install-package automapper -version:4.1
        //open app_start 
        //add a new class called Mapping profile 
        //mapp this when application started so open glocal.aszx

        [HttpGet]
        public IEnumerable<CourseDto> GetCourses()
        {
            return _DbContext.Courses.ToList().Select(Mapper.Map<Course, CourseDto>); 
        }
        public CourseDto GetCourse(int Id)
        {
            var course = _DbContext.Courses.SingleOrDefault(c => c.CourseID == Id);
            if (course == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else

                return  Mapper.Map<Course,CourseDto>(course);
        }
        //Post/courses
        [HttpPost]
        //PostCourse for example is better not to have http post 
        public CourseDto CreateCourse(CourseDto courseDto)
        {
            //Validate the model first 
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            else
            {
                var course = Mapper.Map<CourseDto, Course>(courseDto);
                _DbContext.Courses.Add(course);
                _DbContext.SaveChanges();
                courseDto.CourseID = course.CourseID;
                return courseDto;
            }
        }
        // put api/customers/1 // update 
        [HttpPut]
        public void UpdateCourse(int id, CourseDto courseDto)
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
                    Mapper.Map<CourseDto, Course>(courseDto, courseDb);
                   
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
