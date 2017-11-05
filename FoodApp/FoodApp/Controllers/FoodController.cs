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

        // get the main list page
        public IActionResult List() {
            return View(_context.FoodItems);
        }

        // get the details page
        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            // if id has no value exit
            if (id == null)
            {
                return NotFound();
            }

            // wait for food item
            var food = await _context.FoodItems.SingleOrDefaultAsync(f => f.Id == id);
            // if food item is empty exit
            if (food == null)
            {
                return NotFound();
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
                return RedirectToAction("List");
            }
            else
            {
                // validation error
                return View(foodItem);
            }
        }

        // get the search page


        // post the search page
    }
}
