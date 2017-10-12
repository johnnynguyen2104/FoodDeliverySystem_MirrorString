﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.DomainModels
{
    public class Categories : BaseEntity
    {
        public string CategoryName { get; set; }

        public virtual ICollection<Restaurants> Restaurants { get; set; }
    }
}
