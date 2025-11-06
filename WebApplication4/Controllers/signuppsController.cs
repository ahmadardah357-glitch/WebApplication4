using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class signuppsController : ControllerBase
    {
        private readonly UserDBcontext _context;

        public signuppsController(UserDBcontext context)
        {
            _context = context;
        }

        // GET: api/signupps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<signupp>>> Getsignupps()
        {
            return await _context.signupps.ToListAsync();
        }

        // GET: api/signupps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<signupp>> Getsignupp(int id)
        {
            var signupp = await _context.signupps.FindAsync(id);

            if (signupp == null)
            {
                return NotFound();
            }

            return signupp;
        }

        // PUT: api/signupps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsignupp(int id, signupp signupp)
        {
            if (id != signupp.Id)
            {
                return BadRequest();
            }

            _context.Entry(signupp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!signuppExists(id))
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

        // POST: api/signupps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<signupp>> Postsignupp(signupp signupp)
        {
            _context.signupps.Add(signupp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsignupp", new { id = signupp.Id }, signupp);
        }

        // DELETE: api/signupps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletesignupp(int id)
        {
            var signupp = await _context.signupps.FindAsync(id);
            if (signupp == null)
            {
                return NotFound();
            }

            _context.signupps.Remove(signupp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool signuppExists(int id)
        {
            return _context.signupps.Any(e => e.Id == id);
        }
    }
}
