using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TodoApi2.Dto;
using TodoApi2.Interfaces;
using TodoApi2.Models;

namespace TodoApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            //var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            var categories = _categoryRepository.GetCategories();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(categories);
        }

    }
}
