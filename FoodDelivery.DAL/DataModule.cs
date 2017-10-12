using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL
{
    public class DataModule
    {
        public static void Init(string connectionString)
        {
           UnitOfWork.UnitOfWork.ConnectionString = connectionString;
        }
    }
}
