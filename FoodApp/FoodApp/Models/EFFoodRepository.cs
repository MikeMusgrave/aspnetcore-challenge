using System;
using System.Collections.Generic;

namespace FoodApp.Models
{
    public class EFFoodRepository : IFoodRepository
    {
        private FoodDbContext _context;

        public EFFoodRepository(FoodDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FoodItem> FoodItems => _context.FoodItems;
    }
}
