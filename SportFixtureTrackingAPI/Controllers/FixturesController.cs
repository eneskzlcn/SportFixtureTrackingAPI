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
    public class FixturesController : ControllerBase
    {
        private readonly SportFixturePointContext _context;

        public FixturesController(SportFixturePointContext context)
        {
            _context = context;
        }

        // GET: api/Fixtures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fixture>>> GetFixtures()
        {
            return await _context.Fixtures.ToListAsync();
        }

        // GET: api/Fixtures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fixture>> GetFixture(int id)
        {
            var fixture = await _context.Fixtures.FindAsync(id);

            if (fixture == null)
            {
                return NotFound();
            }

            return fixture;
        }

        // PUT: api/Fixtures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFixture(int id, Fixture fixture)
        {
            if (id != fixture.FixtureId)
            {
                return BadRequest();
            }

            _context.Entry(fixture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixtureExists(id))
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

        // POST: api/Fixtures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fixture>> PostFixture(Fixture fixture)
        {
            _context.Fixtures.Add(fixture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFixture", new { id = fixture.FixtureId }, fixture);
        }

        // DELETE: api/Fixtures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFixture(int id)
        {
            var fixture = await _context.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return NotFound();
            }

            _context.Fixtures.Remove(fixture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FixtureExists(int id)
        {
            return _context.Fixtures.Any(e => e.FixtureId == id);
        }
    }
}
