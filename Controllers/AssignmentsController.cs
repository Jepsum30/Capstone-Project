using AdjusterOptimizerAPI.Data;
using AdjusterOptimizerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdjusterOptimizerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Assignments.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Assignment model)
        {
            _context.Assignments.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.AssignmentId }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Assignment model)
        {
            if (id != model.AssignmentId) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null) return NotFound();

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
