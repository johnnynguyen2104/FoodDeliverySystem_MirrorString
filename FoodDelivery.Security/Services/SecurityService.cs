using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoodDelivery.DAL.DomainModels;
using FoodDelivery.Security.Models;
using Microsoft.AspNet.Identity;

namespace FoodDelivery.Security.Services
{
    public class SecurityService : ISecurityService
    {
        public ApplicationUserManager UserManager;

        public SecurityService(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(string userId, string authenticationType)
        {
            var user = await UserManager.FindByIdAsync(userId);
            return await user.GenerateUserIdentityAsync(UserManager, authenticationType);
        }

        public async Task<UserInformation> FindByIdAsync(string userId)
        {
            Users result = await UserManager.FindByIdAsync(userId);
            return new UserInformation()
            {
                Id = result.Id,
                Email = result.Email,
                UserName = result.UserName,
                PasswordHash = result.PasswordHash
            };
        }

        public Task<IdentityResult> ChangePasswordAsync(string userId, string currentPass, string newPass)
        {
            return UserManager.ChangePasswordAsync(userId, currentPass, newPass);
        }

        public Task<IdentityResult> AddPasswordAsync(string userId, string password)
        {
            return UserManager.AddPasswordAsync(userId, password);
        }

        public Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo loginInfo)
        {
            return UserManager.AddLoginAsync(userId, loginInfo);
        }

        public Task<IdentityResult> RemovePasswordAsync(string userId)
        {
            return UserManager.RemovePasswordAsync(userId);
        }

        public Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo loginInfo)
        {
            return UserManager.RemoveLoginAsync(userId, loginInfo);
        }

        public async Task<UserInformation> FindAsync(UserLoginInfo loginInfo)
        {
            Users user = await UserManager.FindAsync(loginInfo);
            return new UserInformation()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash
            };
        }

        public Task<IdentityResult> CreateAsync(UserInformation user)
        {
            Users userEntity = new Users()
            {
                Email = user.Email,
                UserName = user.Email
            };

            return UserManager.CreateAsync(userEntity, user.PasswordHash);
        }
    }
}
