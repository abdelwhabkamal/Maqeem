using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maqeem.DAL;
using Maqeem.Models;

namespace Maqeem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly MaqeemContext _context;

        public SellerController(MaqeemContext context)
        {
            _context = context;
        }

        // GET: api/Seller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSellers()
        {
          if (_context.Sellers == null)
          {
              return NotFound();
          }
            return await _context.Sellers.ToListAsync();
        }

        // GET: api/Seller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetSeller(uint id)
        {
          if (_context.Sellers == null)
          {
              return NotFound();
          }
            var seller = await _context.Sellers.FindAsync(id);

            if (seller == null)
            {
                return NotFound();
            }

            return seller;
        }

        // PUT: api/Seller/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeller(uint id, Seller seller)
        {
            if (id != seller.SellerID)
            {
                return BadRequest();
            }

            _context.Entry(seller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
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

        // POST: api/Seller
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seller>> PostSeller(Seller seller)
        {
          if (_context.Sellers == null)
          {
              return Problem("Entity set 'MaqeemContext.Sellers'  is null.");
          }
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeller", new { id = seller.SellerID }, seller);
        }

        // DELETE: api/Seller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller(uint id)
        {
            if (_context.Sellers == null)
            {
                return NotFound();
            }
            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SellerExists(uint id)
        {
            return (_context.Sellers?.Any(e => e.SellerID == id)).GetValueOrDefault();
        }
    }
}
