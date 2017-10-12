using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.DomainModels
{
    public class MenuDetails : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ValueBy { get; set; }

        public int MenuId { get; set; }

        public virtual Menu Menu {get;set;}

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
