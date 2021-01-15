using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerWebApiProject.API.DTOs;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Services;

namespace NLayerWebApiProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDTO>(category));
        }
        
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductsDTO>(category));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO entity)
        {
            var result = await _categoryService.AddAsync(_mapper.Map<Category>(entity));
            return Created("", _mapper.Map<CategoryDTO>(result));
        }

        [HttpPut]
        public IActionResult Update(CategoryDTO categoryDto)
        {
            var result = _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var entity = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(entity);
            return NoContent();
        }
    }
}