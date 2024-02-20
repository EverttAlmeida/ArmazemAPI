using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmazemAPI.Context;
using ArmazemAPI.Models;

namespace ArmazemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmazemsController : ControllerBase
    {
        private readonly ArmazemDBContext _context;

        public ArmazemsController(ArmazemDBContext context)
        {
            _context = context;
        }

        // GET: api/Armazems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Armazem>>> GetArmazems()
        {
          if (_context.Armazems == null)
          {
              return NotFound();
          }
            return await _context.Armazems.ToListAsync();
        }

        // GET: api/Armazems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Armazem>> GetArmazem(int id)
        {
          if (_context.Armazems == null)
          {
              return NotFound();
          }
            var armazem = await _context.Armazems.FindAsync(id);

            if (armazem == null)
            {
                return NotFound();
            }

            return armazem;
        }

        // PUT: api/Armazems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmazem(int id, Armazem armazem)
        {
            if (id != armazem.Id)
            {
                return BadRequest();
            }

            _context.Entry(armazem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmazemExists(id))
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

        // POST: api/Armazems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Armazem>> PostArmazem(Armazem armazem)
        {
          if (_context.Armazems == null)
          {
              return Problem("Entity set 'ArmazemDBContext.Armazems'  is null.");
          }
            _context.Armazems.Add(armazem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArmazem", new { id = armazem.Id }, armazem);
        }

        // DELETE: api/Armazems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArmazem(int id)
        {
            if (_context.Armazems == null)
            {
                return NotFound();
            }
            var armazem = await _context.Armazems.FindAsync(id);
            if (armazem == null)
            {
                return NotFound();
            }

            _context.Armazems.Remove(armazem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArmazemExists(int id)
        {
            return (_context.Armazems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
