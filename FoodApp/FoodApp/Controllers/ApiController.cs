using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FoodApp.Models;
using FoodApp.Validation;

namespace FoodApp.Controllers
{
    [Route("api/Food")]
    [ValidateModel]
    public class ApiController : Controller
    {
        private readonly FoodDbContext _context;

        public ApiController(FoodDbContext context)
        {
            _context = context;

            if (_context.FoodItems.Count() == 0)
            {
                _context.FoodItems.Add(new FoodItem { Name = "FoodItem1", Rating = Rating.Unrated });
                _context.SaveChanges();
            }
        }

        // GET all
        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<FoodItem>> Get()
        {
            // get food items from db
            var foodItems = from f in _context.FoodItems select f;

            // order ascending
            foodItems = foodItems.OrderBy(f => f.Name);

            return await foodItems.ToListAsync();
        }

        // GET by guid
        [HttpGet("{id:Guid}", Name ="GetById")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _context.FoodItems.FirstOrDefaultAsync(t => t.Id == id);
            if (item == null)
            {
                return NotFound(id);
            }

            return new ObjectResult(item);
        }

        // POST new from JSON
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Create([FromBody] FoodItem food)
        {
            _context.FoodItems.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetById", new { id = food.Id }, food);
        }
    }
}
