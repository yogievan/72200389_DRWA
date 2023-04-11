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
    public class JadwalGuruController : ControllerBase
    {
        private readonly JadwalGuruContext _context;

        public JadwalGuruController(JadwalGuruContext context)
        {
            _context = context;
        }

        // POST: api/JadwalGuru
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JadwalGuru>> PostJadwalGuru(JadwalGuru jadwalguru)
        {
          if (_context.JadwalGurus == null)
          {
              return Problem("Entity set 'JadwalGuruContext.JadwalGurus'  is null.");
          }
            _context.JadwalGurus.Add(jadwalguru);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetJadwalGuru", new { id = jadwalguru.Id_mapel }, jadwalguru);
            return CreatedAtAction(nameof(GetJadwalGuru), new { id = jadwalguru.Id_mapel }, jadwalguru);
        }

        // GET: api/JadwalGuru
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JadwalGuru>>> GetJadwalGurus()
        {
          if (_context.JadwalGurus == null)
          {
              return NotFound();
          }
            return await _context.JadwalGurus.ToListAsync();
        }

        // GET: api/JadwalGuru/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JadwalGuru>> GetJadwalGuru(long id)
        {
          if (_context.JadwalGurus == null)
          {
              return NotFound();
          }
            var jadwalguru = await _context.JadwalGurus.FindAsync(id);

            if (jadwalguru == null)
            {
                return NotFound();
            }

            return jadwalguru;
        }

        private bool JadwalGuruExists(long id)
        {
            return (_context.JadwalGurus?.Any(e => e.Id_mapel == id)).GetValueOrDefault();
        }
    }
}
