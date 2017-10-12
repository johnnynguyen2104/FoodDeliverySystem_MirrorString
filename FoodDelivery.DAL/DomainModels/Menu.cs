using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.DomainModels
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }

        public int RestaurantId { get; set; }

        public virtual Restaurants Restaurant { get; set; }

        public virtual ICollection<MenuDetails> Details { get; set; }
    }
}
