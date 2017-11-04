using System.Collections.Generic;

namespace FoodApp.Models
{
    public class FakeFoodRepository : IFoodRepository 
    {
        public IEnumerable<FoodItem> FoodItems => new List<FoodItem>
        {
            new FoodItem { Name = "Apple", Rating = RatingEnum.Good },
            new FoodItem { Name = "Burrito", Rating = RatingEnum.Awesome },
            new FoodItem { Name = "Brussel Sprouts", Rating = RatingEnum.Terrible },
            new FoodItem { Name = "Pumpkin Pie", Rating = RatingEnum.Unrated },
            new FoodItem { Name = "Lasagna", Rating = RatingEnum.Awesome },
            new FoodItem { Name = "Bologna", Rating = RatingEnum.Bad },
            new FoodItem { Name = "Tripe", Rating = RatingEnum.Terrible },
        };
    }
}
