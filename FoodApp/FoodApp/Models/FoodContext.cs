using Microsoft.EntityFrameworkCore;

namespace FoodApp.Models
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
