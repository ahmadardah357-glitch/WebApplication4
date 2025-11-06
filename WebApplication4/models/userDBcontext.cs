using Microsoft.EntityFrameworkCore;

namespace WebApplication4.models
{
    public class UserDBcontext : DbContext
    {
        public UserDBcontext(DbContextOptions<UserDBcontext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PasswordReset>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
    }
}
