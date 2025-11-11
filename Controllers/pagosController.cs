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
    public class pagosController : ControllerBase
    {
        private readonly contextDB _context;

        public pagosController(contextDB context)
        {
            _context = context;
        }

        // GET: api/pagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<pagos>>> Getpagos()
        {
            return await _context.pagos.ToListAsync();
        }

        // GET: api/pagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<pagos>> Getpagos(int id)
        {
            var pagos = await _context.pagos.FindAsync(id);

            if (pagos == null)
            {
                return NotFound();
            }

            return pagos;
        }

        // PUT: api/pagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpagos(int id, pagos pagos)
        {
            if (id != pagos.id_pago)
            {
                return BadRequest();
            }

            _context.Entry(pagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pagosExists(id))
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

        // POST: api/pagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<pagos>> Postpagos(pagos pagos)
        {
            _context.pagos.Add(pagos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpagos", new { id = pagos.id_pago }, pagos);
        }

        // DELETE: api/pagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepagos(int id)
        {
            var pagos = await _context.pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            _context.pagos.Remove(pagos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool pagosExists(int id)
        {
            return _context.pagos.Any(e => e.id_pago == id);
        }
    }
}
