using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using FoodDelivery.DAL.Migrations;

namespace FoodDelivery.DAL.DomainModels
{
    public class FoodDeliveryContext: IdentityDbContext<Users>, IDbContext
    {
        public FoodDeliveryContext() :base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FoodDeliveryContext, Configuration>("DefaultConnection"));
        }
        public FoodDeliveryContext(string connectionString)
           : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FoodDeliveryContext, Configuration>(connectionString));
        }

        public static FoodDeliveryContext Create(string connectionString)
        {
            return new FoodDeliveryContext(connectionString);
        }

        int IDbContext.CommitChanges()
        {
            return SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Users>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            builder.Entity<IdentityUserClaim>().ToTable("UserClaims");

            builder.Entity<Categories>()
                                        .HasMany(a => a.Restaurants)
                                        .WithMany(a => a.Categories)
                                        .Map(cs =>
            {
                cs.MapLeftKey("CategoryId");
                cs.MapRightKey("RestaurantId");
                cs.ToTable("CategoriesRestaurants");
            });
            builder.Entity<Categories>().Property(a => a.CategoryName).HasMaxLength(100);

            builder.Entity<Restaurants>().HasKey(a => a.Id);
            builder.Entity<Restaurants>().Property(a => a.RestaurantName).HasMaxLength(100);
            builder.Entity<Restaurants>().HasMany(a => a.Orders).WithRequired(a => a.Restaurant).HasForeignKey(a => a.RestaurantId).WillCascadeOnDelete(false);
            builder.Entity<Restaurants>().HasMany(a => a.Menus).WithRequired(a => a.Restaurant).HasForeignKey(a => a.RestaurantId);

            builder.Entity<UserTypes>().HasMany(a => a.Users).WithRequired(a => a.Type).HasForeignKey(a => a.TypeId);
            builder.Entity<UserTypes>().Property(a => a.TypeName).HasMaxLength(50);

            builder.Entity<Users>().HasMany(a => a.Restaurants).WithRequired(a => a.Owner).HasForeignKey(a => a.OwnerId).WillCascadeOnDelete(false);
            builder.Entity<Users>().HasMany(a => a.Orders).WithRequired(a => a.User).HasForeignKey(a => a.UserId).WillCascadeOnDelete(false);
            builder.Entity<Users>().Property(a => a.FirstName).HasMaxLength(100);
            builder.Entity<Users>().Property(a => a.LastName).HasMaxLength(100);
            builder.Entity<Users>().Property(a => a.Address).HasMaxLength(100);

            builder.Entity<Orders>().HasMany(a => a.Items).WithMany(a => a.Orders).Map(cs => {
                cs.MapLeftKey("OrderId");
                cs.MapRightKey("MenuItemId");
                cs.ToTable("OrdersMenuItems");
            });
            builder.Entity<Orders>().Property(a => a.Address).HasMaxLength(100);
            builder.Entity<Orders>().Property(a => a.Note).HasMaxLength(300);

            builder.Entity<Menu>().Property(a => a.Name).HasMaxLength(50);
            builder.Entity<MenuDetails>().Property(a => a.Name).HasMaxLength(50);

         
            builder.Entity<PaymentHistory>().HasRequired(a => a.Order).WithOptional(a => a.PaymentHistory);

        }
    }
}
