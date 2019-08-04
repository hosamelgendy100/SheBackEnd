using AutoMapper;
using She.Data.Dtos;
using She.Data.Dtos.ProductDtos;
using She.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace She.Data.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<SubCategoryDto, SubCategory>();

            CreateMap<Product, ProductToDisplayDto>();
            CreateMap<ProductToDisplayDto, Product>();

            CreateMap<Product, ProductDetailsDto>();
            CreateMap<ProductDetailsDto, Product>();

            CreateMap<ProductSize, ProductSizesDto>();
            CreateMap<ProductSizesDto, ProductSize>();

        }



    }
}
