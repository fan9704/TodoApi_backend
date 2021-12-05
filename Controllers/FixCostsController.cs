using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi_backend.Data;
using TodoApi_backend.Models;

namespace TodoApi_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FixCostsController : ControllerBase {
        private readonly FixCostContext _context;

        public FixCostsController(FixCostContext context) {
            _context = context;
        }

        // GET: api/FixCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixCost>>> GetFixCost() {
            return await _context.FixCost.ToListAsync();
        }

        // GET: api/FixCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FixCost>> GetFixCost(int id) {
            var fixCost = await _context.FixCost.FindAsync(id);

            if (fixCost == null) {
                return NotFound();
            }

            return fixCost;
        }

        // PUT: api/FixCosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFixCost(int id, FixCost fixCost) {
            if (id != fixCost.Id) {
                return BadRequest();
            }

            _context.Entry(fixCost).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!FixCostExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FixCosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FixCost>> PostFixCost(FixCost fixCost) {
            _context.FixCost.Add(fixCost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFixCost", new { id = fixCost.Id }, fixCost);
        }

        // DELETE: api/FixCosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFixCost(int id) {
            var fixCost = await _context.FixCost.FindAsync(id);
            if (fixCost == null) {
                return NotFound();
            }

            _context.FixCost.Remove(fixCost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FixCostExists(int id) {
            return _context.FixCost.Any(e => e.Id == id);
        }
    }
}
