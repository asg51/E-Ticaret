using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication2.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();


            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
            new Product
            {
                Name = "Iphone 12",
                Description = "Mobil Telefon",
                Category = "Iphone",
                Price = 10000,
                Category1 = "Telefon",
                ImgPath = "../img/phone/iphone-12-pro-family-hero.jpg"

            },
            new Product
            {
                Name = "Oppo Reno 4",
                Description = "Mobil Telefon",
                Category = "Oppo",
                Price = 5000,
                Category1 = "Telefon",
                ImgPath = "../img/phone/oppo-reno-4-128-gb-z.jpg"
            },
            new Product
            {
                Name = "Samsung Galaxy Note 10",
                Description = "Mobil Telefon",
                Category = "Samsung",
                Price = 8000,
                Category1 = "Telefon",
                ImgPath = "../img/phone/samsung-galaxy-note-10-plus-256-gb-z.jpg"
            },
            new Product
            {
                Name = "Xioami Mi Note 10",
                Description = "Mobil Telefon",
                Category = "Xioami",
                Price = 6000,
                Category1 = "Telefon",
                ImgPath = "../img/phone/xioami_mi_note.jpg"
            }
            );
                context.SaveChanges();
            }

        }
    }
}
