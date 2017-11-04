using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FoodApp.Models;

namespace FoodApp.Controllers
{
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        private readonly FoodContext _context;

        public ApiController(FoodContext context)
        {
            _context = context;

            if (_context.FoodItems.Count()==0)
            {
                _context.FoodItems.Add(new FoodItem { Name = "FoodItem1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<FoodItem> GetAll()
        {
            return _context.FoodItems.ToList();
        }

        [HttpGet("{id}", Name = "?id=")]
        public IActionResult GetById(Guid id)
        {
            var item = _context.FoodItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FoodItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.FoodItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("?id=", new { id = item.Id }, item);
        }

        [HttpPut("{id}", Name = "?id=")]
        public IActionResult Update(Guid id, [FromBody] FoodItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var food = _context.FoodItems.FirstOrDefault(t => t.Id == id);
            if (food == null)
            {
                return NotFound();
            }

            food.Name = item.Name;
            food.Rating = item.Rating;
            food.Email = item.Email;
            food.URL = item.URL;

            _context.FoodItems.Update(food);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}", Name = "?id=")]
        public IActionResult Delete(Guid id)
        {
            var food = _context.FoodItems.FirstOrDefault(t => t.Id == id);
            if (food == null)
            {
                return NotFound();
            }

            _context.FoodItems.Remove(food);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
