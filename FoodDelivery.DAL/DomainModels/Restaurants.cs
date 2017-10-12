using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.DomainModels
{
    public class Restaurants : BaseEntity
    {
        public string RestaurantName { get; set; }

        public string Address { get; set; }

        public bool IsActived { get; set; } = true;

        public int OpenTime { get; set; }

        public int CloseTime { get; set; }

        public string OwnerId { get; set; }

        public virtual ICollection<Categories> Categories { get; set; }

        public virtual Users Owner { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
