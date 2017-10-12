using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace FoodDelivery.DAL.DomainModels
{
    public class Users : IdentityUser
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Address { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Users> manager, string authenticationType)
        {
           
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public int? TypeId { get; set; } = 1;

        public bool IsDisabled { get; set; }

        public UserTypes Type { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Restaurants> Restaurants { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
