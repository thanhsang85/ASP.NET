using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
    }

    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Products.Any()) return;

            context.Products.AddRange(
                new Product { Name = "Áo thun basic", Description = "Áo thun cotton 100%, thoáng mát.", Price = 150000, ImageUrl = "https://placehold.co/400x300?text=Ao+Thun" },
                new Product { Name = "Quần jean slimfit", Description = "Quần jean form slimfit, co giãn nhẹ.", Price = 350000, ImageUrl = "https://placehold.co/400x300?text=Quan+Jean" },
                new Product { Name = "Giày sneaker", Description = "Giày sneaker thể thao, đế êm.", Price = 590000, ImageUrl = "https://placehold.co/400x300?text=Sneaker" },
                new Product { Name = "Balo laptop", Description = "Balo chống nước, ngăn laptop 15.6 inch.", Price = 420000, ImageUrl = "https://placehold.co/400x300?text=Balo" }
            );
            context.SaveChanges();
        }
    }
}
