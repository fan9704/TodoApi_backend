using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi_backend.Data;
using TodoApi_backend.Models;

namespace TodoApi_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellRecordsController : ControllerBase
    {
        private readonly SellRecordContext _context;

        public SellRecordsController(SellRecordContext context)
        {
            _context = context;
        }

        // GET: api/SellRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellRecord>>> GetSellRecord()
        {
            return await _context.SellRecord.ToListAsync();
        }

        // GET: api/SellRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellRecord>> GetSellRecord(int id)
        {
            var sellRecord = await _context.SellRecord.FindAsync(id);

            if (sellRecord == null)
            {
                return NotFound();
            }

            return sellRecord;
        }

        // PUT: api/SellRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellRecord(int id, SellRecord sellRecord)
        {
            if (id != sellRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(sellRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellRecordExists(id))
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

        // POST: api/SellRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SellRecord>> PostSellRecord(SellRecord sellRecord)
        {
            _context.SellRecord.Add(sellRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSellRecord", new { id = sellRecord.Id }, sellRecord);
        }

        // DELETE: api/SellRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellRecord(int id)
        {
            var sellRecord = await _context.SellRecord.FindAsync(id);
            if (sellRecord == null)
            {
                return NotFound();
            }

            _context.SellRecord.Remove(sellRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SellRecordExists(int id)
        {
            return _context.SellRecord.Any(e => e.Id == id);
        }
    }
}
