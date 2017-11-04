using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FoodApp.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            // kept getting an error here...found this to help
            // https://stackoverflow.com/questions/46063945/cannot-resolve-dbcontext-in-asp-net-core-2-0

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                FoodDbContext _context = serviceScope.ServiceProvider.GetService<FoodDbContext>();

                if (!_context.FoodItems.Any())
                {
                    _context.FoodItems.AddRange(
                        new FoodItem
                        {
                            Name = "Apple",
                            Rating = RatingEnum.Good,
                            Email = "apple@banana.com",
                            URL = "http://juliandance.org/wp-content/uploads/2016/01/RedApple.jpg"
                        },
                        new FoodItem
                        {
                            Name = "Burrito",
                            Rating = RatingEnum.Awesome,
                            Email = "chico@tacobell.com",
                            URL = "https://d29vij1s2h2tll.cloudfront.net/~/media/images/taco-bell/products/default/22200_burritos_beanburrito_600x600.jpg"
                        },
                        new FoodItem
                        {
                            Name = "Brussel Sprouts",
                            Rating = RatingEnum.Bad,
                            Email = "farmerjohn@plantation.com",
                            URL = "http://4.bp.blogspot.com/-gRve8kQzW70/Vk3hrAK7xvI/AAAAAAAAHUU/sr7E8k6jato/s1600/Bacon%2Bjalapen%25CC%2583o%2Bbrussel%2Bsprouts%2Bgratin_DSC9297.jpg"
                        },
                        new FoodItem
                        {
                            Name = "Pumpkin Pie",
                            Rating = RatingEnum.Unrated,
                            Email = "pilgrim@mayflower.com",
                            URL = "https://images-gmi-pmc.edge-generalmills.com/3cfe0df2-a9a5-4297-9639-c80d66e013c1.jpg"
                        },
                        new FoodItem
                        {
                            Name = "Lasagna",
                            Rating = RatingEnum.Awesome,
                            Email = "geppetto@italiano.com",
                            URL = "https://barilla.azureedge.net/~/media/images/en_us/hero-images/oven-ready-lasagna.jpg"
                        },
                        new FoodItem
                        {
                            Name = "Bologna",
                            Rating = RatingEnum.Bad,
                            Email = "leftover.meat@cow.com",
                            URL = "https://images-na.ssl-images-amazon.com/images/I/51%2BPRp9JzFL._SY355_.jpg"
                        },
                        new FoodItem
                        {
                            Name = "Haggis",
                            Rating = RatingEnum.Terrible,
                            Email = "albert@scottishfoods.com",
                            URL = "https://ichef.bbci.co.uk/news/660/media/images/75904000/jpg/_75904921_154311347.jpg"
                        }
                    );
                    _context.SaveChanges();
                }
            }
        }
    }
}
