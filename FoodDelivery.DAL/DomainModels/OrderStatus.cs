using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.DomainModels
{
    public enum OrderStatus
    {
        Pending = 0,
        Accepted = 1,
        Delivering = 2,
        Done = 3,
        Cancel = 4
    }
}
