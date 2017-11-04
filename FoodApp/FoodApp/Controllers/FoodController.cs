using Microsoft.AspNetCore.Mvc;
using FoodApp.Models;

namespace FoodApp.Controllers
{
    public class FoodController : Controller
    {
        private IFoodRepository repository;

        public FoodController(IFoodRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.FoodItems);
    }
}
