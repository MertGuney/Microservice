using AutoMapper;
using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Models;

namespace FreeCourse.Services.Catalog.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Feature, FeatureDTO>().ReverseMap();

            CreateMap<Course,CourseCreateDTO>().ReverseMap();
            CreateMap<Course,CourseUpdateDTO>().ReverseMap();
        }
    }
}
