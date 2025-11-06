using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebApplication4.models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/password-resets")] // مسار واضح
    public class PasswordResetsController : ControllerBase
    {
        private readonly UserDBcontext _context;

        public PasswordResetsController(UserDBcontext context) => _context = context;

        // GET: api/password-resets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordReset>>> GetAll()
            => await _context.PasswordResets.AsNoTracking().ToListAsync();

        // GET: api/password-resets/5
        [HttpGet("{id:int}", Name = "GetPasswordResetById")]
        public async Task<ActionResult<PasswordReset>> GetById(int id)
        {
            var item = await _context.PasswordResets.FindAsync(id);
            return item is null ? NotFound() : item;
        }

        // GET: api/password-resets/by-user/3
        [HttpGet("by-user/{userId:int}")]
        public async Task<ActionResult<IEnumerable<PasswordReset>>> GetByUser(int userId)
        {
            var items = await _context.PasswordResets
                                      .Where(p => p.UserId == userId)
                                      .OrderByDescending(p => p.Id)
                                      .AsNoTracking()
                                      .ToListAsync();
            return items;
        }

        // POST: api/password-resets   (توليد كود جديد)
        [HttpPost]
        public async Task<ActionResult<PasswordReset>> Create([FromBody] int userId)
        {
            // تأكد أن المستخدم موجود
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists) return BadRequest("User not found.");

            // كود 6 أرقام
            var code = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

            var pr = new PasswordReset
            {
                UserId = userId,
                Reset_code = code,            // عمود Reset_code في الجدول
                Created_at = DateTime.UtcNow, // عمود Created_at
                Expires_at = DateTime.UtcNow.AddMinutes(15), // عمود Expires_at
                Used = false
            };

            _context.PasswordResets.Add(pr);
            await _context.SaveChangesAsync();

            // يرجّع 201 مع رابط الاستعلام
            return CreatedAtRoute("GetPasswordResetById", new { id = pr.Id }, pr);
        }

        // PUT: api/password-resets/5  (تحديث حالة الاستعمال)
        [HttpPut("{id:int}/mark-used")]
        public async Task<IActionResult> MarkUsed(int id)
        {
            var pr = await _context.PasswordResets.FindAsync(id);
            if (pr is null) return NotFound();

            pr.Used = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/password-resets/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pr = await _context.PasswordResets.FindAsync(id);
            if (pr is null) return NotFound();

            _context.PasswordResets.Remove(pr);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}