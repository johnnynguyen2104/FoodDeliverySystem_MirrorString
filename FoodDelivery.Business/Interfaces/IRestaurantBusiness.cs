using FoodDelivery.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Business.Interfaces
{
    public interface IRestaurantBusiness
    {
        IList<RestaurantDto> GetRestaurantsByNameOrCategory(string input);

        MenuDto GetMenuByRestaurant(int restaurantId);

        bool CreateOrUpdateMenu(int restaurantId, MenuDetailsDto detail);
    }
}
