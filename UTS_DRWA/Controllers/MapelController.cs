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
    public class MapelController : ControllerBase
    {
        private readonly MapelContext _context;

        public MapelController(MapelContext context)
        {
            _context = context;
        }

        // POST: api/Mapel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mapel>> PostMapel(Mapel mapel)
        {
          if (_context.Mapels == null)
          {
              return Problem("Entity set 'MapelContext.Mapels'  is null.");
          }
            _context.Mapels.Add(mapel);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMapel", new { id = mapel.Id }, mapel);
            return CreatedAtAction(nameof(GetMapel), new { id = mapel.Id }, mapel);

        }

        // GET: api/Mapel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mapel>>> GetMapels()
        {
          if (_context.Mapels == null)
          {
              return NotFound();
          }
            return await _context.Mapels.ToListAsync();
        }

        // GET: api/Mapel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mapel>> GetMapel(long id)
        {
          if (_context.Mapels == null)
          {
              return NotFound();
          }
            var mapel = await _context.Mapels.FindAsync(id);

            if (mapel == null)
            {
                return NotFound();
            }

            return mapel;
        }

        private bool MapelExists(long id)
        {
            return (_context.Mapels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
