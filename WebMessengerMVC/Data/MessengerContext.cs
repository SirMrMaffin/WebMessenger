using Microsoft.EntityFrameworkCore;
using WebMessengerMVC.Models;

namespace WebMessengerMVC.Data
{
    public class MessengerContext : DbContext
    {
        public MessengerContext(DbContextOptions<MessengerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();
        }

    }
}
