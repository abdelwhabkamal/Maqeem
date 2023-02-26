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

namespace Maskan.Controllers
{
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly MaskanContext _context;

        public PropertyController(MaskanContext context)
        {
            _context = context;
        }

        // GET: api/Property
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties(PaginationParams @params)
        {
            if (_context.Properties == null)
            {
                return NotFound();
            }
            var Properties= _context.Properties;
            var PaginationMetaData = new PaginationMetaData(@params.page, Properties.Count(), @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
            var items=await Properties
		                    .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage)
                            .ToListAsync();
            return items;
        }

        // GET: api/Property/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(uint id)
        {
            if (_context.Properties == null)
            {
                return NotFound();
            }
            var @property = await _context.Properties.FindAsync(id);

            if (@property == null)
            {
                return NotFound();
            }

            return @property;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetCategorizedProperty(FilterSearch filterSearch, PaginationParams @params)
        {
            if (_context.Properties == null)
            {
                return NotFound();
            }
            var Property = await _context.Properties.ToListAsync();
            var PaginationMetaData = new PaginationMetaData(@params.page, Property.Count(), @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
            var items = Property
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            if (filterSearch.DealType != null) 
	        {
                Property = Property.Where(i => i.DealType == filterSearch.DealType).ToList();
                PaginationMetaData = new PaginationMetaData(@params.page, Property.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Property
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.City != null)
            {
                Property = Property.Where(i => i.Country.CountryName == filterSearch.City).ToList();
                PaginationMetaData = new PaginationMetaData(@params.page, Property.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Property
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.Category != null)
            {
                Property = Property.Where(i => i.CategoryGroups.Where(c=>c.Category.CategoryName==filterSearch.Category)!=null).ToList();
                PaginationMetaData = new PaginationMetaData(@params.page, Property.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Property
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.BedsNum != 0)
            {
                Property = Property.Where(i => i.BedsNum == filterSearch.BedsNum).ToList();
                PaginationMetaData = new PaginationMetaData(@params.page, Property.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Property
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.BathsNum != 0)
            {
                Property = Property.Where(i => i.BathsNum == filterSearch.BathsNum).ToList();
                PaginationMetaData = new PaginationMetaData(@params.page, Property.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Property
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.Price != 0)
            {
                Property = Property.Where(i => i.Price == filterSearch.Price).ToList();
                PaginationMetaData = new PaginationMetaData(@params.page, Property.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Property
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.Area != 0)
            {
                Property = Property.Where(i => i.Area == filterSearch.Area).ToList();
                PaginationMetaData = new PaginationMetaData(@params.page, Property.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Property
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            return items;
        }

        // PUT: api/Property/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(uint id, Property @property)
        {
            if (id != @property.PropertyID)
            {
                return BadRequest();
            }

            _context.Entry(@property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Property
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(Property @property)
        {
          if (_context.Properties == null)
          {
              return Problem("Entity set 'MaskanContext.Properties'  is null.");
          }
            _context.Properties.Add(@property);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new { id = @property.PropertyID }, @property);
        }

        // DELETE: api/Property/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(uint id)
        {
            if (_context.Properties == null)
            {
                return NotFound();
            }
            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyExists(uint id)
        {
            return (_context.Properties?.Any(e => e.PropertyID == id)).GetValueOrDefault();
        }
    }
}
