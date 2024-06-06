using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIOpportunities.Data;
using Models;

namespace APIOpportunities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunitiesController : ControllerBase
    {
        private readonly APIOpportunitiesContext _context;

        public OpportunitiesController(APIOpportunitiesContext context)
        {
            _context = context;
        }

        // GET: api/Opportunities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opportunity>>> GetOpportunity()
        {
          if (_context.Opportunity == null)
          {
              return NotFound();
          }
            return await _context.Opportunity.ToListAsync();
        }

        // GET: api/Opportunities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Opportunity>> GetOpportunity(int id)
        {
          if (_context.Opportunity == null)
          {
              return NotFound();
          }
            var opportunity = await _context.Opportunity.FindAsync(id);

            if (opportunity == null)
            {
                return NotFound();
            }

            return opportunity;
        }

        // PUT: api/Opportunities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpportunity(int id, Opportunity opportunity)
        {
            if (id != opportunity.Id)
            {
                return BadRequest();
            }

            _context.Entry(opportunity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpportunityExists(id))
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

        // POST: api/Opportunities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Opportunity>> PostOpportunity(Opportunity opportunity)
        {
          if (_context.Opportunity == null)
          {
              return Problem("Entity set 'APIOpportunitiesContext.Opportunity'  is null.");
          }
            _context.Opportunity.Add(opportunity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOpportunity", new { id = opportunity.Id }, opportunity);
        }

        // DELETE: api/Opportunities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpportunity(int id)
        {
            if (_context.Opportunity == null)
            {
                return NotFound();
            }
            var opportunity = await _context.Opportunity.FindAsync(id);
            if (opportunity == null)
            {
                return NotFound();
            }

            _context.Opportunity.Remove(opportunity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OpportunityExists(int id)
        {
            return (_context.Opportunity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
