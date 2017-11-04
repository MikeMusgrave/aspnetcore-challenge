using System.Collections.Generic;

namespace FoodApp.Models
{
    public interface IFoodRepository
    {
        IEnumerable<FoodItem> FoodItems { get; }
    }
}
