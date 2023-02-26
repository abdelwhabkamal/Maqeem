using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maskan.DAL;
using Maskan.Models;
using System.Text.Json;

namespace Maqeem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly MaskanContext _context;
        
        public BuyerController(MaskanContext context)
        {
            _context = context;
        }

        // GET: api/Buyer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buyer>>> GetBuyers(PaginationParams @params)
        {
          if (_context.Buyers == null)
          {
              return NotFound();
          }
            var Buyers = _context.Buyers;
            var PaginationMetaData = new PaginationMetaData(@params.page, Buyers.Count(), @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
            var items = await Buyers
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage)
                            .ToListAsync();
            return items;
        }

        // GET: api/Buyer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buyer>> GetBuyer(uint id)
        {
          if (_context.Buyers == null)
          {
              return NotFound();
          }
            var buyer = await _context.Buyers.FindAsync(id);

            if (buyer == null)
            {
                return NotFound();
            }

            return buyer;
        }

        // PUT: api/Buyer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyer(uint id, Buyer buyer)
        {
            if (id != buyer.BuyerID)
            {
                return BadRequest();
            }

            _context.Entry(buyer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(id))
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

        // POST: api/Buyer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buyer>> PostBuyer(Buyer buyer)
        {
          if (_context.Buyers == null)
          {
              return Problem("Entity set 'MaskanContext.Buyers'  is null.");
          }
            _context.Buyers.Add(buyer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyer", new { id = buyer.BuyerID }, buyer);
        }

        // DELETE: api/Buyer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyer(uint id)
        {
            if (_context.Buyers == null)
            {
                return NotFound();
            }
            var buyer = await _context.Buyers.FindAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }

            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuyerExists(uint id)
        {
            return (_context.Buyers?.Any(e => e.BuyerID == id)).GetValueOrDefault();
        }
    }
}
