using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.context;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class carritoController : ControllerBase
    {
        private readonly contextDB _context;

        public carritoController(contextDB context)
        {
            _context = context;
        }

        // GET: api/carrito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<carrito>>> Getcarrito()
        {
            return await _context.carrito.ToListAsync();
        }

        // GET: api/carrito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<carrito>> Getcarrito(int id)
        {
            var carrito = await _context.carrito.FindAsync(id);

            if (carrito == null)
            {
                return NotFound();
            }

            return carrito;
        }

        // PUT: api/carrito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcarrito(int id, carrito carrito)
        {
            if (id != carrito.id_carrito)
            {
                return BadRequest();
            }

            _context.Entry(carrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!carritoExists(id))
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

        // POST: api/carrito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<carrito>> Postcarrito(carrito carrito)
        {
            _context.carrito.Add(carrito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcarrito", new { id = carrito.id_carrito }, carrito);
        }

        // DELETE: api/carrito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecarrito(int id)
        {
            var carrito = await _context.carrito.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }

            _context.carrito.Remove(carrito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool carritoExists(int id)
        {
            return _context.carrito.Any(e => e.id_carrito == id);
        }
    }
}
