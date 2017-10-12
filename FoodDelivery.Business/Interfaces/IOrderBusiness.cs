using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.Business.Dtos;

namespace FoodDelivery.Business.Interfaces
{
    public interface IOrderBusiness
    {
        bool AddOrders(OrderDto order);
    }
}
