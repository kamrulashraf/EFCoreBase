using API.DTO.Category;
using AutoMapper;
using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryViewDTO> Get()
        {
            var categories = _categoryService.GetAllCategories();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewDTO>>(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{categoryID}")]
        public CategoryViewDTO Get([Required]int categoryID)
        {
            var category = _categoryService.GetCategory(categoryID);
            return _mapper.Map<Category, CategoryViewDTO>(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post(CategoryCreateDTO category)
        {
            var businessCategoryModel = _mapper.Map<Category>(category);
            _categoryService.AddCategory(businessCategoryModel);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public void Put(CategoryEditDTO category)
        {
            var businessCategoryModel = _mapper.Map<Category>(category);
            _categoryService.UpdateCategory(businessCategoryModel);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{categoryID}")]
        public void Delete(long categoryID)
        {
            _categoryService.DeleteCategory(categoryID);
        }
    }
}
