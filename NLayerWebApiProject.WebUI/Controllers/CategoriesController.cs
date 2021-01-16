using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Services;
using NLayerWebApiProject.WebUI.DTOs;
using NLayerWebApiProject.WebUI.Filters;

namespace NLayerWebApiProject.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            var mappedCategories = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return View(mappedCategories);
        }

        public IActionResult Add()
        {
            return View(new CategoryDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
                return RedirectToAction("Index");
            }

            return View(categoryDto);
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public IActionResult Update(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(_mapper.Map<Category>(categoryDto));
                return RedirectToAction("Index");
            }

            return View(categoryDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (result != null)
            {
                _categoryService.Remove(result);
            }
            return RedirectToAction("Index");
        }
    }
}