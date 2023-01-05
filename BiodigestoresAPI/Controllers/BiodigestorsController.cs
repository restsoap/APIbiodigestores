using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiodigestoresAPI.Data;
using BiodigestoresAPI.Models;

namespace BiodigestoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiodigestorsController : ControllerBase
    {
        private readonly DataContext _context;

        public BiodigestorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Biodigestors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biodigestor>>> GetBiodigestores()
        {
            return await _context.Biodigestores.ToListAsync();
        }

        // GET: api/Biodigestors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Biodigestor>> GetBiodigestor(int id)
        {
            var biodigestor = await _context.Biodigestores.FindAsync(id);

            if (biodigestor == null)
            {
                return NotFound();
            }

            return biodigestor;
        }

        // PUT: api/Biodigestors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiodigestor(int id, Biodigestor biodigestor)
        {
            if (id != biodigestor.Id)
            {
                return BadRequest();
            }

            _context.Entry(biodigestor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiodigestorExists(id))
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

        // POST: api/Biodigestors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Biodigestor>> PostBiodigestor(Biodigestor biodigestor)
        {
            _context.Biodigestores.Add(biodigestor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiodigestor", new { id = biodigestor.Id }, biodigestor);
        }

        // DELETE: api/Biodigestors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiodigestor(int id)
        {
            var biodigestor = await _context.Biodigestores.FindAsync(id);
            if (biodigestor == null)
            {
                return NotFound();
            }

            _context.Biodigestores.Remove(biodigestor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BiodigestorExists(int id)
        {
            return _context.Biodigestores.Any(e => e.Id == id);
        }
    }
}
