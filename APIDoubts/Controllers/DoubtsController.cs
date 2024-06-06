using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDoubts.Data;
using Models;

namespace APIDoubts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoubtsController : ControllerBase
    {
        private readonly APIDoubtsContext _context;

        public DoubtsController(APIDoubtsContext context)
        {
            _context = context;
        }

        // GET: api/Doubts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doubt>>> GetDoubt()
        {
          if (_context.Doubt == null)
          {
              return NotFound();
          }
            return await _context.Doubt.ToListAsync();
        }

        // GET: api/Doubts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doubt>> GetDoubt(int id)
        {
          if (_context.Doubt == null)
          {
              return NotFound();
          }
            var doubt = await _context.Doubt.FindAsync(id);

            if (doubt == null)
            {
                return NotFound();
            }

            return doubt;
        }

        // PUT: api/Doubts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoubt(int id, Doubt doubt)
        {
            if (id != doubt.Id)
            {
                return BadRequest();
            }

            _context.Entry(doubt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoubtExists(id))
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

        // POST: api/Doubts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doubt>> PostDoubt(Doubt doubt)
        {
          if (_context.Doubt == null)
          {
              return Problem("Entity set 'APIDoubtsContext.Doubt'  is null.");
          }
            _context.Doubt.Add(doubt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoubt", new { id = doubt.Id }, doubt);
        }

        // DELETE: api/Doubts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoubt(int id)
        {
            if (_context.Doubt == null)
            {
                return NotFound();
            }
            var doubt = await _context.Doubt.FindAsync(id);
            if (doubt == null)
            {
                return NotFound();
            }

            _context.Doubt.Remove(doubt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoubtExists(int id)
        {
            return (_context.Doubt?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
