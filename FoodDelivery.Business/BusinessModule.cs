using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoodDelivery.Business.Dtos;
using FoodDelivery.DAL;
using FoodDelivery.DAL.DomainModels;

namespace FoodDelivery.Business
{
    public class BusinessModule
    {
        public static void Init(string connectionString)
        {
            DataModule.Init(connectionString);
        }
    }

    public class BusinessMapperProfile : Profile
    {
        public BusinessMapperProfile()
        {
            CreateMap<Orders, OrderDto>().ReverseMap();
        }   
    }
}
