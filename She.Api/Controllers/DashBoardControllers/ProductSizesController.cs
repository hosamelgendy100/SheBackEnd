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
    public class ProductSizesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductSizesController(DataContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSize>>> GetProductSizes()
        {
            return await _context.ProductSizes.Include(p => p.AvailableSize).ToListAsync();
        }


        [HttpGet("{id}")]
        public IActionResult GetProductSize(int id)
        {
            var productSize = _context.ProductSizes
                        .Include(p => p.AvailableSize).Where(p=> p.ProductId ==id);
                        //.FindAsync(id);

            if (productSize == null)
            {
                return BadRequest();
            }

            return Ok(productSize);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSize(int id, ProductSize productSize)
        {
            if (id != productSize.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSizeExists(id))
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



        [HttpPost]
        public async Task<IActionResult> PostProductSize(IEnumerable<ProductSize> productSizes)
        {
            if (productSizes.Count() == 0) return BadRequest("No product sizes selected");

            foreach (var productSize in productSizes)
                _context.ProductSizes.Add(productSize);
            await _context.SaveChangesAsync();
            return Ok(productSizes.Count() + " Added");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductSize>> DeleteProductSize(int id)
        {
            var productSize = await _context.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return NotFound();
            }

            _context.ProductSizes.Remove(productSize);
            await _context.SaveChangesAsync();

            return productSize;
        }


        private bool ProductSizeExists(int id)
        {
            return _context.ProductSizes.Any(e => e.ProductId == id);
        }
    }
}
