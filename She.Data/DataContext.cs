using Microsoft.EntityFrameworkCore;
using She.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace She.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<AvailableColor> AvailableColors { get; set; }
        public DbSet<AvailableSize> AvailableSizes { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Customize Many to Many realtionship from product sizes to products
            builder.Entity<ProductSize>().HasKey(k => new { k.ProductId, k.AvailableSizeId });

            builder.Entity<ProductSize>().HasOne(p => p.Product).WithMany(p => p.ProductSizes)
                                  .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductSize>().HasOne(p => p.AvailableSize).WithMany(p => p.ProductSizes)
                                 .HasForeignKey(p => p.AvailableSizeId).OnDelete(DeleteBehavior.Restrict);

        }




        //-----
    }

}
