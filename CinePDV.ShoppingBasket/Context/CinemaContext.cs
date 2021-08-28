using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinePDV.CafeteriaCatalog.Models;
using CinePDV.MovieCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace CinePDV.ShoppingBasket.Context
{
    public class CinemaContext: DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options)
            :base(options)
        {
            
        }

        public DbSet<CafeteriaCatalog.Models.CategoryDto> CafeteriaCategories;
        public DbSet<MovieCatalog.Models.CategoryDto> MovieCategories;
        public DbSet<ProductDto> Products;
        public DbSet<MovieDto> Movies; 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieCatalog.Models.CategoryDto>().HasKey(k => k.CategoryId);
            modelBuilder.Entity<MovieCatalog.Models.CategoryDto>().Property(k => k.CategoryId).ValueGeneratedOnAdd();
            modelBuilder.Entity<MovieCatalog.Models.CategoryDto>().Property(p => p.Name).HasMaxLength(500);
            modelBuilder.Entity<MovieCatalog.Models.CategoryDto>().HasMany(p => p.Movies)
                .WithOne(movie => movie.Category)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<CafeteriaCatalog.Models.CategoryDto>().HasKey(k => k.CategoryId);
            modelBuilder.Entity<CafeteriaCatalog.Models.CategoryDto>().Property(k => k.CategoryId).ValueGeneratedOnAdd();
            modelBuilder.Entity<CafeteriaCatalog.Models.CategoryDto>().Property(p => p.Name).HasMaxLength(500);
            modelBuilder.Entity<CafeteriaCatalog.Models.CategoryDto>().HasMany(p => p.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<ProductDto>().HasKey(k => k.ProductId);
            modelBuilder.Entity<ProductDto>().Property(k => k.ProductId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductDto>().Property(p => p.Name).HasMaxLength(500);

            modelBuilder.Entity<MovieDto>().HasKey(k => k.MovieId);
            modelBuilder.Entity<MovieDto>().Property(k => k.MovieId).ValueGeneratedOnAdd();
            modelBuilder.Entity<MovieDto>().Property(p => p.Name).HasMaxLength(500);

            //seeding
            /*modelBuilder.Entity<Post>().HasData(new Post
            {
                Content = "Primer post",
                Date = DateTime.Now,
                Id = -1
            });*/
        }
    }
}
