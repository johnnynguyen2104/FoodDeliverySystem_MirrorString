using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.DomainModels
{
    public class UserTypes : BaseEntity
    {
        public string TypeName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
