using AutoMapper;
using NLayerWebApiProject.API.DTOs;
using NLayerWebApiProject.Core.Models;

namespace NLayerWebApiProject.API.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryWithProductsDTO>();
            
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductWithCategoryDTO>();
            CreateMap<ProductWithCategoryDTO, Product>();

            CreateMap<PersonDTO, Person>();
            CreateMap<Person, PersonDTO>();
        }
    }
}