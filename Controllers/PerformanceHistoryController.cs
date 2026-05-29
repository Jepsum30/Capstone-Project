using AdjusterOptimizerAPI.Data;
using AdjusterOptimizerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdjusterOptimizerAPI.Controllers
{
    /// <summary>
    /// Handles all operations related to performance history records,
    /// including CRUD actions and future analytics integration.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PerformanceHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------------
        // GET: api/PerformanceHistory
        // Returns all performance history records.
        // ------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await _context.PerformanceHistory.ToListAsync();
            return Ok(records);
        }

        // ------------------------------------------------------------
        // GET: api/PerformanceHistory/{id}
        // Returns a single performance record by ID.
        // ------------------------------------------------------------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _context.PerformanceHistory.FindAsync(id);

            if (record == null)
                return NotFound("Performance record not found.");

            return Ok(record);
        }

        // ------------------------------------------------------------
        // POST: api/PerformanceHistory
        // Creates a new performance history record.
        // ------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Create(PerformanceHistory model)
        {
            _context.PerformanceHistory.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = model.RecordId }, model);
        }

        // ------------------------------------------------------------
        // PUT: api/PerformanceHistory/{id}
        // Updates an existing performance history record.
        // ------------------------------------------------------------
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PerformanceHistory model)
        {
            if (id != model.RecordId)
                return BadRequest("Record ID mismatch.");

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ------------------------------------------------------------
        // DELETE: api/PerformanceHistory/{id}
        // Deletes a performance history record.
        // ------------------------------------------------------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.PerformanceHistory.FindAsync(id);

            if (record == null)
                return NotFound("Performance record not found.");

            _context.PerformanceHistory.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
