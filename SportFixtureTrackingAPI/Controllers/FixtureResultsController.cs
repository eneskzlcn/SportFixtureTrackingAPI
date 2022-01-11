using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportFixtureTrackingAPI.Models;

namespace SportFixtureTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureResultsController : ControllerBase
    {
        private readonly SportFixturePointContext _context;

        public FixtureResultsController(SportFixturePointContext context)
        {
            _context = context;
        }

        // GET: api/FixtureResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixtureResult>>> GetFixtureResults()
        {
            var fixtureResults = _context.FixtureResults.
                Include(r => r.Fixture).ThenInclude(r => r.HomeTeam).
                Include(r => r.Fixture).ThenInclude(r => r.AwayTeam).
                Include(r => r.WinnerTeam).ThenInclude(w => w.Sport);
            return await fixtureResults.ToListAsync();
        }

        // GET: api/FixtureResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FixtureResult>> GetFixtureResult(int id)
        {
            var fixtureResult = await _context.FixtureResults.FindAsync(id);

            if (fixtureResult == null)
            {
                return NotFound();
            }

            return fixtureResult;
        }

        // PUT: api/FixtureResults/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFixtureResult(int id, FixtureResult fixtureResult)
        {
            if (id != fixtureResult.ResultId)
            {
                return BadRequest();
            }

            _context.Entry(fixtureResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixtureResultExists(id))
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

        // POST: api/FixtureResults
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FixtureResult>> PostFixtureResult(FixtureResult fixtureResult)
        {
            _context.FixtureResults.Add(fixtureResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFixtureResult", new { id = fixtureResult.ResultId }, fixtureResult);
        }

        // DELETE: api/FixtureResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFixtureResult(int id)
        {
            var fixtureResult = await _context.FixtureResults.FindAsync(id);
            if (fixtureResult == null)
            {
                return NotFound();
            }

            _context.FixtureResults.Remove(fixtureResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FixtureResultExists(int id)
        {
            return _context.FixtureResults.Any(e => e.ResultId == id);
        }
    }
}
