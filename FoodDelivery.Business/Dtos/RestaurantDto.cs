using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Business.Dtos
{
    public class RestaurantDto : BaseDto
    {
        public string RestaurantName { get; set; }

        public string Address { get; set; }

        public bool IsActived { get; set; }

        public int OpenTime { get; set; }

        public int CloseTime { get; set; }

        public string OwnerId { get; set; }

        public bool IsDisabled { get; set; }
    }
}
