using System.Collections.Generic;

namespace FoodApp.Models
{
    public class FakeFoodRepository : IFoodRepository 
    {
        public IEnumerable<FoodItem> FoodItems => new List<FoodItem>
        {
            new FoodItem { Name = "Apple", Rating = Rating.Good },
            new FoodItem { Name = "Burrito", Rating = Rating.Awesome },
            new FoodItem { Name = "Brussel Sprouts", Rating = Rating.Terrible },
            new FoodItem { Name = "Pumpkin Pie", Rating = Rating.Unrated },
            new FoodItem { Name = "Lasagna", Rating = Rating.Awesome },
            new FoodItem { Name = "Bologna", Rating = Rating.Bad },
            new FoodItem { Name = "Haggis", Rating = Rating.Terrible },
        };
    }
}
