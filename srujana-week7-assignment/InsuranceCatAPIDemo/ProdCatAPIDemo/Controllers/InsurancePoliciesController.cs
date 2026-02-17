using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceCatAPIDemo.Models;

namespace InsuranceCatAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly InsuranceContext _context;

        public InsurancePoliciesController(InsuranceContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsurancePolicy>>> GetPolicies()
        {
            return await _context.InsurancePolicies
                                 .Include(p => p.InsuranceCategory)
                                 .ToListAsync();
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<InsurancePolicy>> PostPolicy(InsurancePolicy policy)
        {
            var categoryExists = await _context.InsuranceCategories
                                               .AnyAsync(c => c.Id == policy.InsuranceCategoryId);

            if (!categoryExists)
                return BadRequest("Invalid Category Id");

            _context.InsurancePolicies.Add(policy);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPolicies), new { id = policy.Id }, policy);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var policy = await _context.InsurancePolicies.FindAsync(id);

            if (policy == null)
                return NotFound();

            _context.InsurancePolicies.Remove(policy);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
