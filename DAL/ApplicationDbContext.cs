using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DAL.Entities;
namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(x => new { x.OrderId, x.ProductId });

                entity.HasOne(c => c.Product)
                .WithMany(c => c.OrderProducts)
                .HasForeignKey(c => c.ProductId);

                entity.HasOne(c => c.Order)
                .WithMany(c => c.OrderProducts)
                .HasForeignKey(c => c.OrderId);
            });
        }
    }
}
