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
    public class productosController : ControllerBase
    {
        private readonly contextDB _context;

        public productosController(contextDB context)
        {
            _context = context;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<productos>>> Getproductos()
        {
            return await _context.productos.ToListAsync();
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<productos>> Getproductos(int id)
        {
            var productos = await _context.productos.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproductos(int id, productos productos)
        {
            if (id != productos.id_producto)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productosExists(id))
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

        // POST: api/productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<productos>> Postproductos(productos productos)
        {
            _context.productos.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproductos", new { id = productos.id_producto }, productos);
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproductos(int id)
        {
            var productos = await _context.productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.productos.Remove(productos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool productosExists(int id)
        {
            return _context.productos.Any(e => e.id_producto == id);
        }
    }
}
