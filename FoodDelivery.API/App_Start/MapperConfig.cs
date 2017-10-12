using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FoodDelivery.Business;

namespace FoodDelivery.API.App_Start
{
    public static class MapperConfig
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BusinessMapperProfile()); 
            });

            return config;
        }
    }
}