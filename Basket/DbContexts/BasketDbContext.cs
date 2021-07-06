using Basket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DbContexts
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options)
        {

        }

        public DbSet<Entities.Basket> Basket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.Basket>().HasData(new Entities.Basket
            {
                BasketId = Guid.NewGuid().ToString(),
                Count = 1,
               
                Price = 239.99m,
                Username = "Test"
            });
            //modelBuilder.Entity<BasketCart>().HasData(new BasketCart
            //{
            //    Brand = "Nike",
            //    Color = "Black",
            //    Description = "Nike sport shoes for man",
            //    Id = 1,
            //    ImageUrl = "https://img01.ztat.net/article/spp-media-p1/ccd66a56f6c439c7a4a87f9d365ff8f8/45a85d86e84641a8aeb332255c4353aa.jpg",
            //    Price = 239.99m,
            //    CategoryId = 1,
            //    Title = "Blizzard"
            //});

            //modelBuilder.Entity<BasketCart>().HasData(new BasketCart
            //{
            //    Brand = "Bytom",
            //    Color = "White",
            //    Description = "Adidas sport shoes for man",
            //    Id = 2,
            //    ImageUrl = "https://www.bytom.com.pl/files/sc_staging_images/product/normal_img_43791.jpg",
            //    Price = 499.99m,
            //    CategoryId = 2,
            //    Title = "Melvin"
            //});

            //modelBuilder.Entity<BasketCart>().HasData(new BasketCart
            //{
            //    Brand = "Kso Evo",
            //    Color = "Blue",
            //    Description = "Walking shoes",
            //    Id = 3,
            //    ImageUrl = "https://img01.ztat.net/article/spp-media-p1/7915e22f5a323fed81631f9f87aee165/3493cf55c5b1422cbd8614c7c4184af6.jpg?imwidth=1800&filter=packshot",
            //    Price = 439.99m,
            //    CategoryId = 3,
            //    Title = "Kso walking"
            //});

        }

    }
}
