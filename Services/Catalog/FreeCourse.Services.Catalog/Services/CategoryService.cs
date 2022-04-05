using AutoMapper;
using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDTO>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDTO>>.Success(_mapper.Map<List<CategoryDTO>>(categories), 200);
        }

        public async Task<Response<CategoryDTO>> CreateAsync(CategoryDTO categoryDTO)
        {
            var newCategory = _mapper.Map<Category>(categoryDTO);
            await _categoryCollection.InsertOneAsync(newCategory);

            return Response<CategoryDTO>.Success(_mapper.Map<CategoryDTO>(newCategory), 200);
        }

        public async Task<Response<CategoryDTO>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDTO>.Fail("Category Not Found", 404);
            }
            return Response<CategoryDTO>.Success(_mapper.Map<CategoryDTO>(category), 200);
        }
    }
}
