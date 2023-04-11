using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maskan.DAL;
using Maskan.Models;
using System.Text.Json;

namespace Maskan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly MaskanContext _context;

        public SellerController(MaskanContext context)
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
            var Sellers = _context.Sellers;
            var items = await Sellers.ToListAsync();
            return items;
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
              return Problem("Entity set 'MaskanContext.Sellers'  is null.");
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
