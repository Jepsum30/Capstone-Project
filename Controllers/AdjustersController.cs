using AdjusterOptimizerAPI.Data;
using AdjusterOptimizerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdjusterOptimizerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdjustersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdjustersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Adjusters.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.Adjusters.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Adjuster model)
        {
            _context.Adjusters.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.AdjusterId }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Adjuster model)
        {
            if (id != model.AdjusterId) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Adjusters.FindAsync(id);
            if (item == null) return NotFound();

            _context.Adjusters.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
