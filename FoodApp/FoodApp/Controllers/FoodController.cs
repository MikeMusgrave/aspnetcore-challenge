using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        // get the main list page
        public async Task<IActionResult> List() {
            // get food items from db
            var foodItems = from f in _context.FoodItems select f;

            // order ascending
            foodItems = foodItems.OrderBy(f => f.Name);

            return View(await foodItems.ToListAsync());
        }

        // get the details page
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            // check for passed value
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest(id);
            }

            Guid.TryParse(id, out Guid guid);
            
            // get food item
            var food = await _context.FoodItems.SingleOrDefaultAsync(f => f.Id == guid);
            
            // if food item is empty exit
            if (food == null)
            {
                return NotFound(id);
            }

            // everything is good, show the food item's details
            return View(food);

        }

        // get the add page
        public IActionResult Add()
        {
            return View();
        }

        // post the add page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Name, Rating, URL, Email")]FoodItem foodItem)
        {
            // handle action
            if (ModelState.IsValid)
            {
                try
                {
                    // add food item to repository
                    _context.FoodItems.Add(foodItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Please try again.");
                }

                // show list
                //return RedirectToAction("List");
                return RedirectToAction("Details", new { id = foodItem.Id });
            }
            else
            {
                // validation error
                return View(foodItem);
            }
        }

        // get the search page
        public IActionResult Search()
        {
            return View();
        }
    }
}
