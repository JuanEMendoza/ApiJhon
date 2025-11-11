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
    public class pedido_detalleController : ControllerBase
    {
        private readonly contextDB _context;

        public pedido_detalleController(contextDB context)
        {
            _context = context;
        }

        // GET: api/pedido_detalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<pedido_detalle>>> Getpedido_detalle()
        {
            return await _context.pedido_detalle.ToListAsync();
        }

        // GET: api/pedido_detalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<pedido_detalle>> Getpedido_detalle(int id)
        {
            var pedido_detalle = await _context.pedido_detalle.FindAsync(id);

            if (pedido_detalle == null)
            {
                return NotFound();
            }

            return pedido_detalle;
        }

        // PUT: api/pedido_detalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpedido_detalle(int id, pedido_detalle pedido_detalle)
        {
            if (id != pedido_detalle.id_detalle)
            {
                return BadRequest();
            }

            _context.Entry(pedido_detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pedido_detalleExists(id))
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

        // POST: api/pedido_detalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<pedido_detalle>> Postpedido_detalle(pedido_detalle pedido_detalle)
        {
            _context.pedido_detalle.Add(pedido_detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpedido_detalle", new { id = pedido_detalle.id_detalle }, pedido_detalle);
        }

        // DELETE: api/pedido_detalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepedido_detalle(int id)
        {
            var pedido_detalle = await _context.pedido_detalle.FindAsync(id);
            if (pedido_detalle == null)
            {
                return NotFound();
            }

            _context.pedido_detalle.Remove(pedido_detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool pedido_detalleExists(int id)
        {
            return _context.pedido_detalle.Any(e => e.id_detalle == id);
        }
    }
}
