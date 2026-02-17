using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceCatAPIDemo.Models;

namespace InsuranceCatAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceCategoriesController : ControllerBase
    {
        private readonly InsuranceContext _context;

        public InsuranceCategoriesController(InsuranceContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceCategory>>> GetCategories()
        {
            return await _context.InsuranceCategories
                                 .Include(c => c.Policies)
                                 .ToListAsync();
        }

        // GET by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceCategory>> GetCategory(int id)
        {
            var category = await _context.InsuranceCategories
                                         .Include(c => c.Policies)
                                         .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                return NotFound();

            return category;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<InsuranceCategory>> PostCategory(InsuranceCategory category)
        {
            _context.InsuranceCategories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.InsuranceCategories.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.InsuranceCategories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
