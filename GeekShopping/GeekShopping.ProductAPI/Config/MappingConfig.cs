﻿using AutoMapper;
using GeekShopping.ProductAPI.Data.DTO;
using GeekShopping.ProductAPI.Models;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Product>();
                config.CreateMap<Product, ProductDTO>();
            });
            return mappingConfig;
        }
    }
}
