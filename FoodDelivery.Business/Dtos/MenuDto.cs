using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Business.Dtos
{
    public class MenuDto : BaseDto
    {
        public string Name { get; set; }

        public int RestaurantId { get; set; }

        public IList<MenuDetailsDto> Details { get; set; }
    }
}
