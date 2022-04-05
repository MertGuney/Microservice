using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return CreateActionResultInstance(await _categoryService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            return CreateActionResultInstance(await _categoryService.CreateAsync(category));
        }

    }
}
