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
    public class favoritosController : ControllerBase
    {
        private readonly contextDB _context;

        public favoritosController(contextDB context)
        {
            _context = context;
        }

        // GET: api/favoritos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<favoritos>>> Getfavoritos()
        {
            return await _context.favoritos.ToListAsync();
        }

        // GET: api/favoritos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<favoritos>> Getfavoritos(int id)
        {
            var favoritos = await _context.favoritos.FindAsync(id);

            if (favoritos == null)
            {
                return NotFound();
            }

            return favoritos;
        }

        // PUT: api/favoritos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfavoritos(int id, favoritos favoritos)
        {
            if (id != favoritos.id_favorito)
            {
                return BadRequest();
            }

            _context.Entry(favoritos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!favoritosExists(id))
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

        // POST: api/favoritos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<favoritos>> Postfavoritos(favoritos favoritos)
        {
            _context.favoritos.Add(favoritos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfavoritos", new { id = favoritos.id_favorito }, favoritos);
        }

        // DELETE: api/favoritos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefavoritos(int id)
        {
            var favoritos = await _context.favoritos.FindAsync(id);
            if (favoritos == null)
            {
                return NotFound();
            }

            _context.favoritos.Remove(favoritos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool favoritosExists(int id)
        {
            return _context.favoritos.Any(e => e.id_favorito == id);
        }
    }
}
