using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.Security.Models;
using Microsoft.AspNet.Identity;

namespace FoodDelivery.Security.Services
{
    public interface ISecurityService
    {
        Task<ClaimsIdentity> GenerateUserIdentityAsync(string userId, string authenticationType);
        Task<UserInformation> FindByIdAsync(string userId);

        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPass, string newPass);

        Task<IdentityResult> AddPasswordAsync(string userId, string password);

        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo loginInfo);

        Task<IdentityResult> RemovePasswordAsync(string userId);

        Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo loginInfo);

        Task<UserInformation> FindAsync(UserLoginInfo loginInfo);

        Task<IdentityResult> CreateAsync(UserInformation user);
    }
}
