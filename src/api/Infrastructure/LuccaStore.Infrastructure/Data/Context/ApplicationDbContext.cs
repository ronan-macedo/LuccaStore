using LuccaStore.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LuccaStore.Infrastructure.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderLinesEntity> OrderLines { get; set; }
        public DbSet<PaymentMethodEntity> PaymentMethods { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CategoryEntity>().ToTable("Categories");
            builder.Entity<OrderEntity>().ToTable("Orders");
            builder.Entity<OrderLinesEntity>().ToTable("OrderLines");
            builder.Entity<PaymentMethodEntity>().ToTable("PaymentMethods");
            builder.Entity<ProductEntity>().ToTable("Products");
            builder.Entity<StorageEntity>().ToTable("Storages");

            /**
             * Seeding Identity Users and User Roles.
             */
            var userId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();
            var adminRoleId = Guid.NewGuid().ToString();

            // Create roles.
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = userRoleId
                });

            // Create user.
            var identityUser = new IdentityUser
            {
                Id = userId,
                UserName = "admin.user",
                NormalizedUserName = "ADMIN.USER",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                EmailConfirmed = true
            };

            // Set password.
            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
            identityUser.PasswordHash = hasher.HashPassword(identityUser, "1234abc");

            // Create user in with EF.
            builder.Entity<IdentityUser>().HasData(identityUser);

            // Set roles to the new user.
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = userId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = userId
                });


        }
    }
}
