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
    public class AvailableColorsController : ControllerBase
    {
        private readonly DataContext _context;

        public AvailableColorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AvailableColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailableColor>>> GetAvailableColors()
        {
            return await _context.AvailableColors.ToListAsync();
        }

        // GET: api/AvailableColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvailableColor>> GetAvailableColor(int id)
        {
            var availableColor = await _context.AvailableColors.FindAsync(id);

            if (availableColor == null)
            {
                return NotFound();
            }

            return availableColor;
        }

        // PUT: api/AvailableColors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailableColor(int id, AvailableColor availableColor)
        {
            if (id != availableColor.Id)
            {
                return BadRequest();
            }

            _context.Entry(availableColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailableColorExists(id))
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

        // POST: api/AvailableColors
        [HttpPost]
        public async Task<ActionResult<AvailableColor>> PostAvailableColor(AvailableColor availableColor)
        {
            _context.AvailableColors.Add(availableColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvailableColor", new { id = availableColor.Id }, availableColor);
        }

        // DELETE: api/AvailableColors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AvailableColor>> DeleteAvailableColor(int id)
        {
            var availableColor = await _context.AvailableColors.FindAsync(id);
            if (availableColor == null)
            {
                return NotFound();
            }

            _context.AvailableColors.Remove(availableColor);
            await _context.SaveChangesAsync();

            return availableColor;
        }

        private bool AvailableColorExists(int id)
        {
            return _context.AvailableColors.Any(e => e.Id == id);
        }
    }
}
