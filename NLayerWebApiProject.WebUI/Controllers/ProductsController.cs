using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerWebApiProject.WebUI.ApiService;
using NLayerWebApiProject.WebUI.DTOs;

namespace NLayerWebApiProject.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProductApiService _productApiService;

        public ProductsController(IMapper mapper, ProductApiService productApiService)
        {
            _mapper = mapper;
            _productApiService = productApiService;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();
            return View(products);
        }

        public IActionResult Add()
        {
            return View(new ProductDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDTO productDto)
        {
            var product = await _productApiService.AddAsync(productDto);
            if (product != null)
            {
                return RedirectToAction("Index");
            }

            return View(productDto);
        }
    }
}