using LmsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LmsContext _context;

        public UserController(LmsContext context)
        {
            _context = context;
        }
        // GET: Get all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.Where(u => u.RoleId == 1 || u.RoleId == 2).ToListAsync();
            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // GET: Get user by id
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(long userId)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return user;
            
        }

        // GET: Users by role
        [HttpGet("Role/{roleId}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByRole(int roleId)
        {
            var usersByRole =  await _context.Users.Where(u => u.RoleId == roleId).ToListAsync();
            
            if (usersByRole == null)
            {
                return NotFound();
            }

            return usersByRole;
        }

        // POST: Add new user
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { userId = newUser.Id }, newUser);
        }

        // PUT: Edit details of a specific user
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(long userId, User user)
        {
            if (userId != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                if (!UserExists(userId))
                {
                    return NotFound();
                }
                else
                {
                    throw err;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(r => r.Id == id); 
        }
    }
}
