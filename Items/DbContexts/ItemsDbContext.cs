using Items.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.DbContexts
{
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Brand = "Nike",
                Color = "Black",
                Description = "Nike sport shoes for man",
                Id = 1,
                ImageUrl = "https://img01.ztat.net/article/spp-media-p1/ccd66a56f6c439c7a4a87f9d365ff8f8/45a85d86e84641a8aeb332255c4353aa.jpg",
                Price = 239.99m,
                CategoryId = 1,
                Title = "Blizzard"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Brand = "Bytom",
                Color = "White",
                Description = "Adidas sport shoes for man",
                Id = 2,
                ImageUrl = "https://www.bytom.com.pl/files/sc_staging_images/product/normal_img_43791.jpg",
                Price = 499.99m,
                CategoryId = 2,
                Title = "Melvin"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Brand = "Kso Evo",
                Color = "Blue",
                Description = "Walking shoes",
                Id = 3,
                ImageUrl = "https://img01.ztat.net/article/spp-media-p1/7915e22f5a323fed81631f9f87aee165/3493cf55c5b1422cbd8614c7c4184af6.jpg?imwidth=1800&filter=packshot",
                Price = 439.99m,
                CategoryId = 3,
                Title = "Kso walking"
            });


            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                Name = "Sport"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 2,
                Name = "Elegant"
            });
            
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 3,
                Name = "Casual"
            });
        }

    }
}
