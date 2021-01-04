using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishesApi.Models;

namespace webappdishes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly DishesContext _context;

        public DishesController(DishesContext context)
        {
            _context = context;
        }

        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dishes>>> GetDishesItems()
        {
            return await _context.DishesItems.ToListAsync();
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dishes>> GetDishes(long id)
        {

            IDishesService dishes;
            
            dishes = await _context.DishesItems.FindAsync(id);

            if (dishes == null)
            {
                return NotFound();
            }

            Dishes dishes1 = new Dishes();
            dishes1.Id = 1;

            return dishes1;
        }

        // PUT: api/Dishes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishes(long id, Dishes dishes)
        {
            if (id != dishes.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dishes
        [HttpPost]
        public async Task<ActionResult<Dishes>> PostDishes(Dishes dishes)
        {
            _context.DishesItems.Add(dishes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishes", new { id = dishes.Id }, dishes);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dishes>> DeleteDishes(long id)
        {
            var dishes = await _context.DishesItems.FindAsync(id);
            if (dishes == null)
            {
                return NotFound();
            }

            _context.DishesItems.Remove(dishes);
            await _context.SaveChangesAsync();

            return dishes;
        }

        private bool DishesExists(long id)
        {
            return _context.DishesItems.Any(e => e.Id == id);
        }
    }
}
