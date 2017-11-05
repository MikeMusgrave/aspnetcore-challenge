using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodApp.Models;

namespace FoodApp.Controllers
{
    public class FoodController : Controller
    {
        private readonly FoodDbContext _context;

        public FoodController(FoodDbContext context)
        {
            _context = context;
        }

        public IActionResult List() {
            return View(_context.FoodItems);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var food = await _context.FoodItems.SingleOrDefaultAsync(f => f.Id == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);

        }

        [HttpPost]
        public ViewResult Add(FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                // add food item to repository
                return View("List");
            }
            else
            {
                // validation error
                return View();
            }
        }
    }
}
