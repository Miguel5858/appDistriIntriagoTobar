using ECommerce_NetCore.Entities;
using ECommerce_NetCore.Entities.Segurity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.DataAccess
{
    public class ECommerceNetCoreDbContext : DbContext
    {
        public ECommerceNetCoreDbContext()
        {
            
        }

        public ECommerceNetCoreDbContext(DbContextOptions<ECommerceNetCoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property<decimal>(p => p.UnitPrice).HasPrecision(8, 2);

            modelBuilder.Entity<Sale>().Property(p => p.TotalSale).HasPrecision(8, 2).IsRequired();

            modelBuilder.Entity<SaleDetail>().Property(p => p.UnitPrice).HasPrecision(8, 2).IsRequired();

            modelBuilder.Entity<SaleDetail>().Property(p => p.Quantity).HasPrecision(8, 2).IsRequired();

            modelBuilder.Entity<SaleDetail>().Property(p => p.Total).HasPrecision(8, 2).IsRequired();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }


        public DbSet<Sale> Sales { get; set; }


        public DbSet<SaleDetail> SaleDetails { get; set; }


        public DbSet<Usuario> Usuarios { get; set; }

    }
}
