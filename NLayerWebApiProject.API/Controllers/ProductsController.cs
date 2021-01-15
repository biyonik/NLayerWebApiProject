using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerWebApiProject.API.DTOs;
using NLayerWebApiProject.API.Filters;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Services;

namespace NLayerWebApiProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDTO>(product));    
        }

        [HttpGet("{id}/category")]
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDTO>(product));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }
        
        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Save(ProductDTO entity)
        {
            var result = await _productService.AddAsync(_mapper.Map<Product>(entity));
            return Created("", _mapper.Map<ProductDTO>(result));
        }
        
        [HttpPut]
        public IActionResult Update(ProductDTO productDto)
        {
            var result = _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public IActionResult Remove(int id)
        {
            var entity = _productService.GetByIdAsync(id).Result;
            _productService.Remove(entity);
            return NoContent();
        }
    }
}