using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FoodApp.Models;

namespace FoodApp
{
    // was getting errors...found this to help
    // https://github.com/Ibro/DesignTimeDbContextFactory

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FoodDbContext>
    {
        public FoodDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<FoodDbContext>();
            builder.UseSqlServer(configuration["Data:FoodAppFoodItems:ConnectionString"]);

            return new FoodDbContext(builder.Options);
        }
    }
}
