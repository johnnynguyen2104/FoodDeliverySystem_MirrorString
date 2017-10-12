using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.DomainModels
{
    public class PaymentHistory : BaseEntity
    {

        public decimal Total { get; set; }
        
        public string TransactionId { get; set; }

        public virtual Orders Order { get; set; }
    }
}
