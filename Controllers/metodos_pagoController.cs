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
    public class metodos_pagoController : ControllerBase
    {
        private readonly contextDB _context;

        public metodos_pagoController(contextDB context)
        {
            _context = context;
        }

        // GET: api/metodos_pago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<metodos_pago>>> Getmetodos_pago()
        {
            return await _context.metodos_pago.ToListAsync();
        }

        // GET: api/metodos_pago/5
        [HttpGet("{id}")]
        public async Task<ActionResult<metodos_pago>> Getmetodos_pago(int id)
        {
            var metodos_pago = await _context.metodos_pago.FindAsync(id);

            if (metodos_pago == null)
            {
                return NotFound();
            }

            return metodos_pago;
        }

        // PUT: api/metodos_pago/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmetodos_pago(int id, metodos_pago metodos_pago)
        {
            if (id != metodos_pago.id_metodo)
            {
                return BadRequest();
            }

            _context.Entry(metodos_pago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!metodos_pagoExists(id))
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

        // POST: api/metodos_pago
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<metodos_pago>> Postmetodos_pago(metodos_pago metodos_pago)
        {
            _context.metodos_pago.Add(metodos_pago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmetodos_pago", new { id = metodos_pago.id_metodo }, metodos_pago);
        }

        // DELETE: api/metodos_pago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemetodos_pago(int id)
        {
            var metodos_pago = await _context.metodos_pago.FindAsync(id);
            if (metodos_pago == null)
            {
                return NotFound();
            }

            _context.metodos_pago.Remove(metodos_pago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool metodos_pagoExists(int id)
        {
            return _context.metodos_pago.Any(e => e.id_metodo == id);
        }
    }
}
