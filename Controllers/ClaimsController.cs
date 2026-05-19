using AdjusterOptimizerAPI.Data;
using AdjusterOptimizerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdjusterOptimizerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Claims.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null) return NotFound();
            return Ok(claim);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Claim model)
        {
            _context.Claims.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.ClaimId }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Claim model)
        {
            if (id != model.ClaimId) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null) return NotFound();

            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
