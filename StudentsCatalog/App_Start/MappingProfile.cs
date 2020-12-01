using AutoMapper;
using StudentsCatalog.Models;
using StudentsCatalog.Dtos;

namespace StudentsCatalog.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Course, CourseDto>();
            Mapper.CreateMap<CourseDto, Course>();
        }
    }
}