using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.DomainModels
{
    public class Orders : BaseEntity
    {
        public string Address { get; set; }

        public int RestaurantId { get; set; }

        public string UserId { get; set; }

        public string Note { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.None;

        public Restaurants Restaurant { get; set; }

        public Users User { get; set; }

        public PaymentHistory PaymentHistory { get; set; }

        public virtual ICollection<MenuDetails> Items { get; set; }
    }
}
