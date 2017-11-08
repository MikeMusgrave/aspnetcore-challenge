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

        // GET: List
        public async Task<IActionResult> List() {
            // get food items from db
            var foodItems = from f in _context.FoodItems select f;

            // order ascending
            foodItems = foodItems.OrderBy(f => f.Name);

            return View(await foodItems.ToListAsync());
        }

        // GET: List/Details/<guid>
        public async Task<IActionResult> Details(Guid? id)
        {
            // check for passed value
            if (id == null)
            {
                return View("ItemNotFound");
            }

            // get food item
            var food = await _context.FoodItems.SingleOrDefaultAsync(f => f.Id == id);
            
            // if food item is empty exit
            if (food == null)
            {
                return View("ItemNotFound");
            }

            // everything is good, show the food item's details
            return View(food);

        }

        // GET: List/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: List/Create
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

        // GET: List/Search
        public IActionResult Search()
        {
            return View();
        }

        // GET: List/Edit/<guid>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, Name, Rating, URL, Email")] FoodItem foodItem)
        {
            if (id != foodItem.Id)
            {
                return View("ItemNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodItemExists(foodItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = foodItem.Id });
            }
            return View(foodItem);
        }

        // GET: List/Delete/<guid>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return View("ItemNotFound");
            }

            var foodItem = await _context.FoodItems.SingleOrDefaultAsync(f => f.Id == id);
            if (foodItem == null)
            {
                return View("ItemNotFound");
            }

            return View(foodItem);
        }

        // POST: List/Delete/<guid>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var food = await _context.FoodItems.SingleOrDefaultAsync(f => f.Id == id);
            _context.FoodItems.Remove(food);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        private bool FoodItemExists(Guid id)
        {
            return _context.FoodItems.Any(f => f.Id == id);
        }
    }
}
