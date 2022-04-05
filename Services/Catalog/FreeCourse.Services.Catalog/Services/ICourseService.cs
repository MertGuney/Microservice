using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDTO>>> GetAllAsync();
        Task<Response<CourseDTO>> GetByIdAsync(string id);
        Task<Response<List<CourseDTO>>> GetAllByUserIdAsync(string userId);
        Task<Response<CourseDTO>> CreateAsync(CourseCreateDTO courseCreateDTO);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDTO courseUpdateDTO);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
