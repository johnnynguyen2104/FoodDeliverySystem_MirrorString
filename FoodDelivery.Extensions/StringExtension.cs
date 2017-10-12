using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Extensions
{
    public static class StringExtension
    {
        public static bool HasValue(this string input)
        {
            return (!string.IsNullOrEmpty(input) && input.Trim().Length > 0);
        }
    }
}
