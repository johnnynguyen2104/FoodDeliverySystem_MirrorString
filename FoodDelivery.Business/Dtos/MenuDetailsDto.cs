using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Business.Dtos
{
    public class MenuDetailsDto : BaseDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ValueBy { get; set; }

        public int MenuId { get; set; }
    }
}
