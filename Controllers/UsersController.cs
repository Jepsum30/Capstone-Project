using AdjusterOptimizerAPI.Data;
using AdjusterOptimizerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdjusterOptimizerAPI.Controllers
{
    /// <summary>
    /// Handles all user-related operations including registration,
    /// password changes, and standard CRUD operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------------
        // GET: api/Users
        // Returns all users in the system.
        // ------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        // ------------------------------------------------------------
        // GET: api/Users/{id}
        // Returns a single user by ID.
        // ------------------------------------------------------------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        // ------------------------------------------------------------
        // POST: api/Users/register
        // Registers a new user with password complexity validation
        // and secure password hashing.
        // ------------------------------------------------------------
        [HttpPost("register")]
        public async Task<IActionResult> Register(User model)
        {
            // Validate password complexity
            if (!User.ValidatePassword(model.PasswordHash))
            {
                return BadRequest("Password must be at least 8 characters, include upper/lowercase letters, a number, and a symbol.");
            }

            // Hash password before saving
            string hashed = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            model.PasswordHash = hashed;

            _context.Users.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully.", model.UserId });
        }

        // ------------------------------------------------------------
        // PUT: api/Users/change-password/{id}
        // Allows a user to change their password with validation.
        // ------------------------------------------------------------
        [HttpPut("change-password/{id}")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] string newPassword)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("User not found.");

            // Validate new password
            if (!User.ValidatePassword(newPassword))
            {
                return BadRequest("Password must be at least 8 characters, include upper/lowercase letters, a number, and a symbol.");
            }

            // Hash and update
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _context.SaveChangesAsync();

            return Ok("Password updated successfully.");
        }

        // ------------------------------------------------------------
        // POST: api/Users
        // Standard create (not used for registration).
        // ------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            _context.Users.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.UserId }, model);
        }

        // ------------------------------------------------------------
        // PUT: api/Users/{id}
        // Updates user fields (not password).
        // ------------------------------------------------------------
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User model)
        {
            if (id != model.UserId)
                return BadRequest("User ID mismatch.");

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ------------------------------------------------------------
        // DELETE: api/Users/{id}
        // Deletes a user from the system.
        // ------------------------------------------------------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
