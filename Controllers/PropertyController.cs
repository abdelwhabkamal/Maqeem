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
        [HttpGet]
        public async Task<IActionResult> GetAllProperties()
        {
            if (_context.Properties == null)
            {
                return NotFound();
            }
            else
            {
                var properties = await _context.Properties.ToListAsync();

                return Ok(properties);
            }
        }

        // GET: api/Property
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties([FromQuery]PaginationParams @params)
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
        public async Task<ActionResult<IEnumerable<Property>>> GetCategorizedProperty(FilterSearch filterSearch,[FromQuery] PaginationParams @params)
        {
            if (_context.Properties == null)
            {
                return NotFound();
            }
            var Properties = _context.Properties;
            var PaginationMetaData = new PaginationMetaData(@params.page, Properties.Count(), @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
            var items = await Properties
		                        .Skip((@params.page - 1) * @params.ItemsPerPage)
                                .Take(@params.ItemsPerPage).ToListAsync();
            if (filterSearch.DealType != null) 
	        {
                Properties = (DbSet<Property>)Properties.Where(i => i.DealType == filterSearch.DealType);
                PaginationMetaData = new PaginationMetaData(@params.page, Properties.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Properties
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
           /*
            * if (filterSearch.City != null)
            {
                Properties = (DbSet<Property>)Properties.Where(i => i.Country.CountryName == filterSearch.City);
                PaginationMetaData = new PaginationMetaData(@params.page, Properties.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Properties
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
           */
            if (filterSearch.Category != null)
            {
                Properties = (DbSet<Property>)Properties.Where(i => i.CategoryGroups.Where(c=>c.Category.CategoryName==filterSearch.Category)!=null);
                PaginationMetaData = new PaginationMetaData(@params.page, Properties.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Properties
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.BedsNum != 0)
            {
                Properties = (DbSet<Property>)Properties.Where(i => i.BedsNum == filterSearch.BedsNum);
                PaginationMetaData = new PaginationMetaData(@params.page, Properties.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Properties
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.BathsNum != 0)
            {
                Properties = (DbSet<Property>)Properties.Where(i => i.BathsNum == filterSearch.BathsNum);
                PaginationMetaData = new PaginationMetaData(@params.page, Properties.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Properties
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.Price != 0)
            {
                Properties = (DbSet<Property>)Properties.Where(i => i.Price == filterSearch.Price);
                PaginationMetaData = new PaginationMetaData(@params.page, Properties.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Properties
                            .Skip((@params.page - 1) * @params.ItemsPerPage)
                            .Take(@params.ItemsPerPage).ToList();
            }
            if (filterSearch.Area != 0)
            {
                Properties = (DbSet<Property>)Properties.Where(i => i.Area == filterSearch.Area);
                PaginationMetaData = new PaginationMetaData(@params.page, Properties.Count(), @params.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData));
                items = Properties
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

        [HttpPost]
        public async Task<ActionResult<Images>> PostImages(Images image)
        {
            if (_context.Images == null)
            {
                return Problem("Entity set 'MaskanContext.Images'  is null.");
            }
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProperty", new { id = image.ImagesID }, image);
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
        [HttpPost]
        public float PredictPrice(ModelInput property)
        {
            if (property.DealType == 0)
            {
                var SampleData = new MLModel.ModelInput()
                {
                    Type = 0,
                    Area = property.Area,
                    Bedrooms = property.RoomsNum,
                    Bathrooms = property.BathsNum,
                    Region = property.Region

                };
                var Result = MLModel.Predict(SampleData);
                return Result.Score;
            }
            else
            {

                var SampleData = new MLModel1.ModelInput()
                {
                    Type = 0,
                    Area = property.Area,
                    Bedrooms = property.RoomsNum,
                    Bathrooms = property.BathsNum,
                    Region = property.Region,
                    Furnished=property.Furnished,
                };
                var Result = MLModel1.Predict(SampleData);
                return Result.Score;
            }
        }


        private bool PropertyExists(uint id)
        {
            return (_context.Properties?.Any(e => e.PropertyID == id)).GetValueOrDefault();
        }
    }
}
