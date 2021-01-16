using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using NLayerWebApiProject.WebUI.DTOs;

namespace NLayerWebApiProject.WebUI.ApiService
{
    public class ProductApiService
    {
        private readonly HttpClient _client;
        public ProductApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<ProductDTO> productDtos = new List<ProductDTO>();
            var response = await _client.GetAsync("Products");
            productDtos = response.IsSuccessStatusCode 
                        ? JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(await response.Content.ReadAsStringAsync()) 
                        : null;

            return productDtos;
        }

        public async Task<ProductDTO> AddAsync(ProductDTO productDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("Products", content);
            productDto = response.IsSuccessStatusCode 
                ? JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync()) 
                : null;
            return productDto;
        }
    }
}