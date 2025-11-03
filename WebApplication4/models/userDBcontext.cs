using Microsoft.EntityFrameworkCore;

namespace WebApplication4.models
{
    public class UserDBcontext : DbContext
    {
        public UserDBcontext(DbContextOptions<UserDBcontext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
