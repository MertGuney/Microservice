using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDTO>>> GetAllAsync();
        Task<Response<CategoryDTO>> CreateAsync(CategoryDTO categoryDTO);
        Task<Response<CategoryDTO>> GetByIdAsync(string id);
    }
}
