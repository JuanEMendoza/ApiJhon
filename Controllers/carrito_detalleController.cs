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
    public class carrito_detalleController : ControllerBase
    {
        private readonly contextDB _context;

        public carrito_detalleController(contextDB context)
        {
            _context = context;
        }

        // GET: api/carrito_detalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<carrito_detalle>>> Getcarrito_detalle()
        {
            return await _context.carrito_detalle.ToListAsync();
        }

        // GET: api/carrito_detalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<carrito_detalle>> Getcarrito_detalle(int id)
        {
            var carrito_detalle = await _context.carrito_detalle.FindAsync(id);

            if (carrito_detalle == null)
            {
                return NotFound();
            }

            return carrito_detalle;
        }

        // PUT: api/carrito_detalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcarrito_detalle(int id, carrito_detalle carrito_detalle)
        {
            if (id != carrito_detalle.id_detalle)
            {
                return BadRequest();
            }

            _context.Entry(carrito_detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!carrito_detalleExists(id))
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

        // POST: api/carrito_detalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<carrito_detalle>> Postcarrito_detalle(carrito_detalle carrito_detalle)
        {
            _context.carrito_detalle.Add(carrito_detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcarrito_detalle", new { id = carrito_detalle.id_detalle }, carrito_detalle);
        }

        // DELETE: api/carrito_detalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecarrito_detalle(int id)
        {
            var carrito_detalle = await _context.carrito_detalle.FindAsync(id);
            if (carrito_detalle == null)
            {
                return NotFound();
            }

            _context.carrito_detalle.Remove(carrito_detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool carrito_detalleExists(int id)
        {
            return _context.carrito_detalle.Any(e => e.id_detalle == id);
        }
    }
}
