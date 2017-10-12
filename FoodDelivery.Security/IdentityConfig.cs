using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using FoodDelivery.DAL.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;



namespace FoodDelivery.Security
{
    public class ApplicationUserManager : UserManager<Users>
    {
        public ApplicationUserManager(IUserStore<Users> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<Users>(context.Get<FoodDeliveryContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<Users>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<Users>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
