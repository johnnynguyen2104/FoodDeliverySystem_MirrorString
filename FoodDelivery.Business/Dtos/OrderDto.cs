using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Business.Dtos
{
    public class OrderDto : BaseDto
    {
        public string Address { get; set; }

        public int RestaurantId { get; set; }

        public string UserId { get; set; }

        public string Note { get; set; }

        public int Status { get; set; }

        public int PaymentStatus { get; set; } = 0;

        public virtual IList<MenuDetailsDto> Items { get; set; }
    }
}
