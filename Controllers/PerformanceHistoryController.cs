using AdjusterOptimizerAPI.Data;
using AdjusterOptimizerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdjusterOptimizerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PerformanceHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.PerformanceHistory.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.PerformanceHistory.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PerformanceHistory model)
        {
            _context.PerformanceHistory.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.RecordId }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PerformanceHistory model)
        {
            if (id != model.RecordId) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.PerformanceHistory.FindAsync(id);
            if (item == null) return NotFound();

            _context.PerformanceHistory.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
