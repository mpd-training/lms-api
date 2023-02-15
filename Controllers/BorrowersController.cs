using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LmsApi.Models;

namespace LmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowersController : ControllerBase
    {
        private readonly LmsContext _context;

        public BorrowersController(LmsContext context)
        {
            _context = context;
        }

        // GET: api/Borrowers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetBorrowers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Borrowers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetBorrower(long id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var borrower = await _context.Users.FindAsync(id);

            if (borrower == null)
            {
                return NotFound();
            }

            return borrower;
        }

        // PUT: api/Borrowers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrower(long id, User borrower)
        {
            if (id != borrower.Id)
            {
                return BadRequest();
            }

            _context.Entry(borrower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Borrowers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostBorrower(User borrower)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'LibraryContext.Borrowers'  is null.");
          }
            _context.Users.Add(borrower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrower", new { id = borrower.Id }, borrower);
        }

        // DELETE: api/Borrowers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrower(long id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var borrower = await _context.Users.FindAsync(id);
            if (borrower == null)
            {
                return NotFound();
            }

            _context.Users.Remove(borrower);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BorrowerExists(long id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
