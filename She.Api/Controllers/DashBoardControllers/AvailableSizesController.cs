using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using She.Data;
using She.Data.Models;

namespace She.Api.Controllers.DashBoardControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableSizesController : ControllerBase
    {
        private readonly DataContext _context;

        public AvailableSizesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AvailableSizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailableSize>>> GetAvailableSizes()
        {
            return await _context.AvailableSizes.ToListAsync();
        }

        // GET: api/AvailableSizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvailableSize>> GetAvailableSize(int id)
        {
            var availableSize = await _context.AvailableSizes.FindAsync(id);

            if (availableSize == null)
            {
                return NotFound();
            }

            return availableSize;
        }

        // PUT: api/AvailableSizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailableSize(int id, AvailableSize availableSize)
        {
            if (id != availableSize.Id)
            {
                return BadRequest();
            }

            _context.Entry(availableSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailableSizeExists(id))
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

        // POST: api/AvailableSizes
        [HttpPost]
        public async Task<ActionResult<AvailableSize>> PostAvailableSize(AvailableSize availableSize)
        {
            _context.AvailableSizes.Add(availableSize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvailableSize", new { id = availableSize.Id }, availableSize);
        }

        // DELETE: api/AvailableSizes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AvailableSize>> DeleteAvailableSize(int id)
        {
            var availableSize = await _context.AvailableSizes.FindAsync(id);
            if (availableSize == null)
            {
                return NotFound();
            }

            _context.AvailableSizes.Remove(availableSize);
            await _context.SaveChangesAsync();

            return availableSize;
        }

        private bool AvailableSizeExists(int id)
        {
            return _context.AvailableSizes.Any(e => e.Id == id);
        }
    }
}
