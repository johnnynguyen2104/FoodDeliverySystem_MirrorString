using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.DomainModels
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatedDate => DateTime.Now;

        public DateTime? UpdatedDate { get; set; }
    }
}
