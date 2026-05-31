using AdjusterOptimizerAPI.Data;
using AdjusterOptimizerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdjusterOptimizerAPI.Controllers
{
    /// <summary>
    /// Handles all operations related to insurance claims,
    /// including CRUD actions and wildcard search functionality.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------------
        // GET: api/Claims
        // Returns all claims in the system.
        // ------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var claims = await _context.Claims.ToListAsync();
            return Ok(claims);
        }

        // ------------------------------------------------------------
        // GET: api/Claims/{id}
        // Returns a single claim by ID.
        // ------------------------------------------------------------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var claim = await _context.Claims.FindAsync(id);

            if (claim == null)
                return NotFound("Claim not found.");

            return Ok(claim);
        }

        // ------------------------------------------------------------
        // POST: api/Claims
        // Creates a new claim record.
        // ------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Create(Claim model)
        {
            _context.Claims.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = model.ClaimId }, model);
        }

        // ------------------------------------------------------------
        // PUT: api/Claims/{id}
        // Updates an existing claim.
        // ------------------------------------------------------------
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Claim model)
        {
            if (id != model.ClaimId)
                return BadRequest("Claim ID mismatch.");

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ------------------------------------------------------------
        // DELETE: api/Claims/{id}
        // Deletes a claim from the system.
        // ------------------------------------------------------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var claim = await _context.Claims.FindAsync(id);

            if (claim == null)
                return NotFound("Claim not found.");

            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ------------------------------------------------------------
        // GET: api/Claims/search?query=auto
        // Performs a wildcard search across multiple claim fields.
        // ------------------------------------------------------------
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Claim>>> SearchClaims(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Search query cannot be empty.");

            // Wildcard search using EF Core + MySQL LIKE
            var results = await _context.Claims
                .Where(c =>
                    EF.Functions.Like(c.ClaimType, $"%{query}%") ||
                    EF.Functions.Like(c.Status, $"%{query}%") ||
                    EF.Functions.Like(c.Jurisdiction, $"%{query}%"))
                .ToListAsync();

            return Ok(results);
        }
    }
}
