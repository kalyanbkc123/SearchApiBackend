
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using SearchApi.Models;

namespace SearchApi.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using System.Collections.Generic;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // public DbSet<Product> Products { get; set; }  // DbSet for Products

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<BestSellerRank> BestSellerRanks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Product-ProductDetails one-to-one relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Details)
                .WithOne()
                .HasForeignKey<Product>(p => p.ProductDetailsId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if ProductDetails is removed

            // Configure the ProductDetails-BestSellerRank one-to-one relationship
            modelBuilder.Entity<ProductDetails>()
                .HasOne(pd => pd.BestSellerRank)
                .WithOne()
                .HasForeignKey<ProductDetails>(pd => pd.BestSellerRankId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if BestSellerRank is removed

            base.OnModelCreating(modelBuilder);
        }
    }

}
