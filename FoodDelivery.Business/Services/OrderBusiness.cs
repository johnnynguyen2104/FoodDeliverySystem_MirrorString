using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoodDelivery.Business.Dtos;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DAL.DomainModels;
using FoodDelivery.DAL.Interfaces;
using FoodDelivery.DAL.UnitOfWork;

namespace FoodDelivery.Business.Services
{
    public class OrderBusiness : IOrderBusiness
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;

        public OrderBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public OrderBusiness(IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _mapper = mapper;
        }

        public bool AddOrders(OrderDto order)
        {
            if (order != null && string.IsNullOrEmpty(order.UserId) && order.RestaurantId > 0)
            {
                var orderEntity = _mapper.Map<Orders>(order);

                _unitOfWork.OrdersRepository.Create(orderEntity);

                return _unitOfWork.CommitChanges() > 0;
            }

            return false;
        }
    }
}
