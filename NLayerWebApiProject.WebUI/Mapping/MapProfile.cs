using System.Collections.Generic;
using AutoMapper;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.WebUI.DTOs;

namespace NLayerWebApiProject.WebUI.Mapping
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