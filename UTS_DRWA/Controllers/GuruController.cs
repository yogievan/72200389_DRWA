using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UTS_DRWA.Models;

namespace UTS_DRWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuruController : ControllerBase
    {
        private readonly GuruContext _context;

        public GuruController(GuruContext context)
        {
            _context = context;
        }

        // POST: api/Guru
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guru>> PostGuru(Guru guru)
        {
          if (_context.Gurus == null)
          {
              return Problem("Entity set 'GuruContext.Gurus'  is null.");
          }
            _context.Gurus.Add(guru);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGuru", new { id = guru.nip }, guru);
            return CreatedAtAction(nameof(GetGuru), new { id = guru.nip }, guru);
            
        }

        // GET: api/Guru
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guru>>> GetGurus()
        {
          if (_context.Gurus == null)
          {
              return NotFound();
          }
            return await _context.Gurus.ToListAsync();
        }

        // GET: api/Guru/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guru>> GetGuru(long id)
        {
          if (_context.Gurus == null)
          {
              return NotFound();
          }
            var guru = await _context.Gurus.FindAsync(id);

            if (guru == null)
            {
                return NotFound();
            }

            return guru;
        }

        private bool GuruExists(long id)
        {
            return (_context.Gurus?.Any(e => e.nip == id)).GetValueOrDefault();
        }
    }
}
