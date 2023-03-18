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
        }
    }
}
